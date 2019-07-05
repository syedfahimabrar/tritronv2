import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
import {BehaviorSubject, ReplaySubject} from 'rxjs';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
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
  token = new ReplaySubject<string>();
  tok = this.token.asObservable();
  profilepic = new ReplaySubject<string>();
  propic = this.profilepic.asObservable();
  constructor(private http:HttpClient,private jwthelper:JwtHelperService,private router:Router,private tst:ToastrService) {
    this.token.next(localStorage.getItem('token'));
  }
  register(model:any){
    return this.http.post(this.baseUrl+'register', model);
  }
  login(model:any){
    return this.http.post<LoginResponse>(this.baseUrl+'login',model);
  }
  loggedin(token:string){
    this.token.next(token);
    this.profilepic.next(this.jwthelper.decodeToken(token).profilepic);
    this.tst.success('Welcome '+this.jwthelper.decodeToken(token).unique_name+'!!','Welcome');
    this.router.navigateByUrl('/');
  }
  logout(){
    localStorage.removeItem('token');
    this.token.next(null);
    this.profilepic.next(null);
  }
  isExpired(to:string){
    console.log("token is "+to);
    return this.jwthelper.isTokenExpired(to);
  }
}
