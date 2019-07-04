import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = "https://localhost:44311/api/auth/"
  constructor(private http:HttpClient) { }
  register(model:any){
    return this.http.post(this.baseUrl+'register', model);
  }
}
