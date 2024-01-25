import { Component, OnInit } from '@angular/core';
import { ParkingsService } from '../_services/parkings.service';
import { Observable } from 'rxjs';
import { Parking } from '../_models/parking';

@Component({
  selector: 'app-parkings',
  templateUrl: './parkings.component.html',
  styleUrls: ['./parkings.component.scss']
})
export class ParkingsComponent implements OnInit{
  parkings: Observable<Parking[]> | undefined;

  constructor(private parkingService: ParkingsService){}

  ngOnInit(): void {
    this.getParkings();
  }

  getParkings(){
    this.parkings = this.parkingService.getParkings();
    console.log(this.parkings);
  }
}
