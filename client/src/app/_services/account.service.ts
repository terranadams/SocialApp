import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService { // this service will be responsible for making HTTP requests from our client to our server
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model)
  }
}
