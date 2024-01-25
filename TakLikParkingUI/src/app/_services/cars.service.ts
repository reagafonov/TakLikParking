import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../_models/car';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  
  baseUrl = "https://localhost:44382/api/"

  constructor(private http: HttpClient) { }

  getParkings(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + 'Parking/list/1/100');
  }

}
