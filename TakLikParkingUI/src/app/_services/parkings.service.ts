import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'
import { Parking } from '../_models/parking';

@Injectable({
  providedIn: 'root'
})
export class ParkingsService {
  baseUrl = "https://localhost:44382/api/"

  constructor(private http: HttpClient) { }

  getParkings(): Observable<Parking[]> {
    return this.http.get<Parking[]>(this.baseUrl + 'Parking/list/1/100');
  }

}
