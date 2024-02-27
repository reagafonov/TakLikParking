import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { Person } from './_models/person';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'TakLikParkingUI';

  constructor(private accountService: AccountService){}
  
  ngOnInit(){
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString)return;
    const user: Person = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
