import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  private isTranssub  = new BehaviorSubject<boolean>(false);
  isTrans = this.isTranssub.asObservable();
  constructor() { }
  changeIsTrans(isTrans:boolean){
    this.isTranssub.next(isTrans);
  }

}
