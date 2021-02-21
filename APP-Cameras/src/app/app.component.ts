import { Component, ModuleWithComponentFactories, OnInit } from '@angular/core';
import { CameraService, ICamera } from './services/camera.service';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { tileLayer, latLng, marker } from 'leaflet';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'APP-Cameras';

  camera_data : ICamera[];

  Column35cameras : ICamera[] = [];
  Column3cameras : ICamera[] = [];
  Column5cameras : ICamera[] = [];
  ColumnOthercameras : ICamera[] = [];

  options = {
    layers: [
      tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 18, attribution: '...' })
    ],
    zoom: 15,
    center: latLng(52.0914, 5.1115)
  };

  layers = []
  
  constructor(
    private cameraService : CameraService){}

  ngOnInit() {
    this.cameraService.getCameraList().subscribe(
      result => {
        this.MapCameras(result);
      });
    
  }

  private MapCameras(result : ICamera[]){
    for(var i=0; i < result.length; i++){
      var cameraObj : ICamera = {
        id : result[i].id,
        number : result[i].number,
        description : result[i].description,
        name : result[i].name,
        latitude : result[i].latitude,
        longitude : result[i].longitude
      }

      switch(true){
        case result[i].number%3 == 0 && result[i].number%5 == 0:
          this.Column35cameras.push(cameraObj);
          break;
        case result[i].number%3 == 0:
          this.Column3cameras.push(cameraObj);
          break;
        case result[i].number%5 == 0:
          this.Column5cameras.push(cameraObj);
          break;
        default : 
          this.ColumnOthercameras.push(cameraObj);
          break;
      }
      
      var markerObj = marker([result[i].latitude, result[i].longitude])

      this.layers.push(markerObj)
      
    }
  }
}


