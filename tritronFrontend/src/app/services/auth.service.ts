import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
import {BehaviorSubject, ReplaySubject, Subject} from 'rxjs';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {environment} from '../../environments/environment';
export interface LoginResponse {
  succeeded: boolean;
  token: string;
  error: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl+"api/auth/";
  token = new BehaviorSubject<string>(null);
  profilepic = new BehaviorSubject<string>(null);
  isloggedin = new BehaviorSubject<boolean>(null);
  isAdmin = new BehaviorSubject<boolean>(null);
  constructor(private http:HttpClient,private jwthelper:JwtHelperService,private router:Router,private tst:ToastrService) {
    this.token.next(localStorage.getItem('token'));
    if(!this.isExpired(localStorage.getItem('token')))
      this.isloggedin.next(true);
    if(!this.isExpired(localStorage.getItem('token')))
      this.profilepic.next(jwthelper.decodeToken(localStorage.getItem('token')).profilepic);
    if(!this.isExpired(localStorage.getItem('token')))
      this.isAdmin.next(jwthelper.decodeToken(localStorage.getItem('token')).role);
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
    this.isloggedin.next(true);
    this.isAdmin.next(this.jwthelper.decodeToken(localStorage.getItem('token')).role);
    if(this.jwthelper.decodeToken(token).role === 'admin')
      this.router.navigateByUrl('/admin/problem/create');
    else
      this.router.navigateByUrl('/');
  }
  logout(){
    localStorage.removeItem('token');
    this.token.next(null);
    this.profilepic.next(null);
    this.isloggedin.next(false);
  }
  isExpired(to:string){
    console.log("token is "+to);
    return this.jwthelper.isTokenExpired(to);
  }
}
