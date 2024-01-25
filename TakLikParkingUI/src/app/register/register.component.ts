import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit{
  model: any = {};
  @Output() cancelRegister = new EventEmitter();

  constructor(){}

  ngOnInit(): void {
  }

  register(){
    console.log(this.model);
  }

  cancel(){
    this.cancelRegister.emit(false);
  }

}
