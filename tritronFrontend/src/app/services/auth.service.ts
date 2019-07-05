import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
export interface LoginResponse {
  succeeded: boolean;
  token: string;
  error: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = "https://localhost:44311/api/auth/";
  isLoggedin:boolean;
  constructor(private http:HttpClient,private jwthelper:JwtHelperService) {
    this.isLoggedin = this.loggedin();
  }
  register(model:any){
    return this.http.post(this.baseUrl+'register', model);
  }
  login(model:any){
    return this.http.post<LoginResponse>(this.baseUrl+'login',model);
  }
  loggedin(){
    var token = localStorage.getItem('token');
    if(token)
      this.jwthelper.isTokenExpired(token);
    return !!token;
  }
}
