// IMessageService.cs
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Logging;

public class MessageService : BackgroundService
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly IHubContext<MessageHub> _hubContext;
    private readonly ILogger<MessageService> _logger;

    public MessageService(ConnectionFactory connectionFactory, IHubContext<MessageHub> hubContext, ILogger<MessageService> logger)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("MessageService is starting...");

        try
        {
            Console.WriteLine("MessageService is starting...");

            await ProcessMessagesAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error starting MessageService: {ex.Message}");
        }
    }

    private async Task ProcessMessagesAsync(CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            try
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");

                // Send the message to connected clients through SignalR
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing message: {ex.Message}");
            }
        };

        channel.BasicConsume(queue: "hello",
                             autoAck: true,
                             consumer: consumer);

        // Wait until cancellation is requested
        await Task.Delay(Timeout.Infinite, cancellationToken);
    }
}




