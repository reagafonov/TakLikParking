import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit{
  model: any = {};
  loggedIn = true;

  constructor(private accountService: AccountService, private router: Router){}

  ngOnInit(): void {
    //this.getCurrentUser();
  }
  
  getCurrentUser(){
    this.accountService.currentUser$.subscribe({
      next: user => this.loggedIn = !!user,
      error: error => console.log(error)
    })
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: () => {
        this.router.navigateByUrl('/bookings')
        this.loggedIn = true;
      },
      error: error => console.log(error)
    })
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    this.loggedIn = false;
  }
}
