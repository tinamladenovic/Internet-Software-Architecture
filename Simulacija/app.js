const express = require('express');
const axios = require('axios');
const amqp = require('amqplib');
const cors = require('cors');
const app = express();
const port = 3000;

app.use(express.json());
app.use(cors())
app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', '*'); // Allow requests from any origin
  res.header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE'); // Specify the allowed methods
  res.header('Access-Control-Allow-Headers', 'Content-Type'); // Specify the allowed headers
  next();
});
const apiKey = '5b3ce3597851110001cf6248758a64b34a154ce49dd3613422432ab4'; // Replace with your actual API key



const headers = {
  Authorization: `Bearer ${apiKey}`,
};
let intervalId;
let intervalz;
let lastPoint;
app.post('/send-coordinates', async (req, res) => {
  if (intervalId) {
    clearInterval(intervalId);
  }
  try {
    const { interval,pocetak,kraj } = req.body;
    intervalz = interval;
    let pocetakz = pocetak
    if (lastPoint) {
      pocetakz = [lastPoint.lng,lastPoint.lat]
    }
    const routeRequest = {
      coordinates: [pocetakz, kraj],
      profile: 'driving-car', // You can change this to 'foot-walking', 'cycling-regular', etc.
      format: 'geojson',
    };

    if (!intervalz) {
      return res.status(400).json({ error: 'Interval is required in the request body.' });
    }

    const connection = await amqp.connect('amqp://localhost'); // Replace with your RabbitMQ server URL
    const channel = await connection.createChannel();
    const queue = 'hello';
    const durable = false;

    await channel.assertQueue(queue, { durable });

    // Make OpenRouteService API request
    const response = await axios.post('https://api.openrouteservice.org/v2/directions/driving-car/geojson', routeRequest, { headers });
    const route = response.data.features[0];
    const coordinates = route.geometry.coordinates.map(point => ({
      lat: point[1],
      lng: point[0],
    }));

    // Send each coordinate to RabbitMQ periodically
    let index = 0;
    intervalId = setInterval(() => {
      if (index < coordinates.length) {
        channel.sendToQueue(queue, Buffer.from(JSON.stringify(coordinates[index])));
        lastPoint = coordinates[index+1]
        console.log(lastPoint)
        index++;
      } else {
        clearInterval(intervalId); // Stop the interval when all coordinates are sent
        channel.close();
        connection.close();
      }
    }, intervalz * 1000); // Convert seconds to milliseconds

    res.status(200).json({ message: 'Coordinates will be sent periodically.' });
  } catch (error) {
    console.error('Error:', error.response ? error.response.data : error.message);
    res.status(500).json({ error: 'Internal Server Error' });
  }
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});