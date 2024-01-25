import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs'
import { Person } from '../_models/person';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:44382/api/"
  private currentUserSource = new BehaviorSubject<Person | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post<Person>(this.baseUrl + 'person/login', model).pipe(
      map((response: Person) => {
          const user = response;
          if(user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
          }
      })
    )
  }

  setCurrentUser(user: Person){
    this.currentUserSource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
