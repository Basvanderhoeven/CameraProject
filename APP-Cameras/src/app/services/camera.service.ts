import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from '@angular/common/http';

@Injectable()

export class CameraService {

  constructor(private http : HttpClient) { 
    this.getCameraList();
  }
  
  public movieDetail : ICamera;

  getCameraList(){
    var baseURL = "http://localhost:50674/api/Cameras";
    let headers = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Access-Control-Allow-Origin', 'http://localhost:50674/api/Cameras')
    .set('Access-Control-Allow-Methods', 'GET');
    return this.http.get<ICamera[]>(baseURL, { headers : headers});
  }

  getCamerasByDescription(descr){
    var baseURL = "http://localhost:50674/api/Cameras/name/";

    if(descr != ""){
      baseURL += descr
    }

    let headers = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Access-Control-Allow-Origin', 'http://localhost:50674/api/Cameras')
    .set('Access-Control-Allow-Methods', 'GET');

    return this.http.get<ICamera[]>(baseURL, { headers : headers});
  }
 
}

export interface ICamera {
  id: number;
  number: number;
  name: string;
  description: string;
  latitude: number;
  longitude: number;
  column?: number;
}
export interface ICameras {
  cameras: ICameras[];
}