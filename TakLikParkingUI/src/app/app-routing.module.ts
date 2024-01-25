import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarListComponent } from './cars/car-list/car-list.component';
import { CarDetailsComponent } from './cars/car-details/car-details.component';
import { ParkingsComponent } from './parkings/parkings.component';
import { BookingsComponent } from './bookings/bookings.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'cars', component: CarListComponent},
  {path: 'car/:id', component: CarDetailsComponent},
  {path: 'parkings', component: ParkingsComponent},
  {path: 'bookings', component: BookingsComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
