import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProblemService {

  baseurl = environment.apiUrl+'problem/';
  constructor(private http:HttpClient) { }
  submitProblem(model:any){
    return this.http.post(this.baseurl,model);
  }
  getProblem(id){
    return this.http.get(this.baseurl+id);
  }
  getAll(pageNumber=1,pageSize=5){
    console.log('pagenumber',pageNumber);
    console.log('pagesize',pageSize);
    if(pageNumber==1&& pageSize==5)
      return this.http.get(this.baseurl);
    return this.http.get(this.baseurl+'/?pageNumber='+pageNumber+'&pageSize='+pageSize);
  }
  getsearched(searchquery):Observable<any>{
      console.log(searchquery);
    return this.http.get(this.baseurl+'/query?query='+searchquery);
  }
  getLanguages(){
    return this.http.get(this.baseurl+'language');
  }
}
