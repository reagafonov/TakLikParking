import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  registerMode = false;
  users: any;

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  getUsers(){
    this.http.get('https://localhost:44382/Person/list/1/100').subscribe({
      next: responce => this.users = responce,
      error: error => console.log(error),
      complete: () => console.log("Request completed")      
    })
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }
}
