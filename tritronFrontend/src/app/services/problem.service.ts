import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProblemService {

  baseurl = environment.apiUrl+'problem';
  constructor(private http:HttpClient) { }
  submitProblem(model:any){
    return this.http.post(this.baseurl,model);
  }
  getProblem(id){
    return this.http.get(this.baseurl+'/'+id);
  }
}
