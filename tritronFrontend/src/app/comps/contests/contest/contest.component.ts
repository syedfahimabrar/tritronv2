import { Component, OnInit } from '@angular/core';
import {interval, Observable, timer} from 'rxjs';
import {take} from 'rxjs/operators';
import {ContestService} from '../../../_services/contest.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-contest',
  templateUrl: './contest.component.html',
  styleUrls: ['./contest.component.scss']
})
export class ContestComponent implements OnInit {

  contest;
  date;
  pay;
  //start time greater than now
  stgnow$:Observable<boolean>;

  constructor(private service: ContestService,private route:ActivatedRoute) {
    this.service.GetContest(this.route.snapshot.paramMap.get('id')).
        subscribe( (res)=> {
          this.contest = res;
          console.log(this.contest);
          this.stgnow$  =new Observable((observer)=>{
            observer.next((new Date(res.startTime).getTime() > new Date().getTime()));
          });
          console.log(this.stgnow$);
        });
    console.log(this.contest);
    this.date = new Date().getTime();
    console.log(this.date);
  }

  ngOnInit() {

  }


}
