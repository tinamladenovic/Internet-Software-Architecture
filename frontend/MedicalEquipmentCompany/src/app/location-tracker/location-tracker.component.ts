import { Component, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignalRService } from '../signalr.service';
import { BrowserModule } from '@angular/platform-browser';
import { Feature, Map, View } from 'ol';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import Attribution from 'ol/source/OSM'
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import { fromLonLat } from 'ol/proj';
import { Point } from 'ol/geom';
import Style from 'ol/style/Style';
import Icon from 'ol/style/Icon';
import { AppService } from '../../app.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-location-tracker',
  standalone: true,
  imports: [CommonModule,FormsModule],
  providers: [SignalRService,],
  templateUrl: './location-tracker.component.html',
  styleUrl: './location-tracker.component.css'
})
export class LocationTrackerComponent {
  @ViewChild('mapElement') mapElement?: ElementRef;
  messages: string[] = [];
  private map!: Map;
  private markerLayer!: any;
  private marker!: Feature;
  public updateRate:any;

  constructor(private signalRService: SignalRService,private appService:AppService) {
  }

  ngOnInit(): void {
    console.log('ngOnInit', this.mapElement);
    this.signalRService.message$.subscribe((message) => {
      this.messages.push(message);
      console.log(message)
      let coords = JSON.parse(message)
      this.updateMarkerPosition([coords.lng, coords.lat]);
    });
  }

  ngAfterViewInit(): void {
    console.log('ngAfterViewInit', this.mapElement);
    this.initializeMap();
    this.addMarker([19.7749461,45.244959]);
    let ul  = document.getElementsByTagName('ul')[0]
    ul.remove()
  }

  changeRate() {
    this.appService.updateRate(parseInt(this.updateRate)).subscribe((data)=>{
      console.log(data)
    })
  }

  private initializeMap(): void {
    if (this.mapElement) {
      this.map = new Map({
        target: this.mapElement.nativeElement,
        layers: [
          new TileLayer({
            source: new OSM(),
          }),
        ],
        view: new View({
          center: fromLonLat([19.7749461,45.244959]),
          zoom: 12,
        }),
      });

      // Initialize marker layer
      const markerSource = new VectorSource<Feature<Point>>();
      this.markerLayer = new VectorLayer({
        source: markerSource,
      });

      if (this.map) {
        this.map.addLayer(this.markerLayer);
      }
    }
  }
  private addMarker(coordinates: [number, number]): void {
    const markerStyle = new Style({
      image: new Icon({
        anchor: [0.5, 1],
        src: 'https://cdn-icons-png.freepik.com/512/6823/6823535.png',
        scale: 0.05, // Replace with the path to your marker icon
      }),
    });

    this.marker = new Feature(new Point(fromLonLat(coordinates)));
    this.marker.setStyle(markerStyle);

    const markerSource = this.markerLayer.getSource();
    markerSource.clear(); // Clear existing markers
    markerSource.addFeature(this.marker);
  }

  public updateMarkerPosition(newCoordinates: [number, number]): void {
    if (this.marker) {
      const markerGeometry = this.marker.getGeometry() as Point;
      markerGeometry.setCoordinates(fromLonLat(newCoordinates));

      // Optionally, re-center the map to the new marker position
      this.map.getView().setCenter(fromLonLat(newCoordinates));
    }
  }
}