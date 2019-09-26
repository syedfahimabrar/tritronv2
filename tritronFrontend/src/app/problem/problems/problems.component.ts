import { Component, OnInit } from '@angular/core';
import {ProblemService} from '../../_services/problem.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ProblemsModel} from '../../_Models/problems.model';
import {SocproblemsService} from '../../_signalr/socproblems.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-problems',
  templateUrl: './problems.component.html',
  styleUrls: ['./problems.component.scss']
})
export class ProblemsComponent implements OnInit {

  problems;
  public pagenumber;
  public totalPage;
  hello = 5;
  private socSubscription: Subscription;
  constructor(private service:ProblemService,private route:ActivatedRoute,
              private socproblem:SocproblemsService,private router:Router) {
    this.pagenumber =(this.route.snapshot.queryParams['pageNumber']==null?1:this.route.snapshot.queryParams['pageNumber']);
    console.log(this.pagenumber);
    this.service.getAll(this.pagenumber,5).subscribe((res:ProblemsModel)=>{
      console.log(res);
      this.problems = res.problem;
      this.totalPage = res.totalCount;
    });
    this.socproblem.connect();
    this.socproblem.getMessage().on("send",(payload)=>{
      this.loadPage(this.pagenumber);
    });
    console.log(this.pagenumber);
    console.log(this.totalPage);
  }
  loadPage(pagenumber){
    this.router.navigate([], {
      queryParams: {
        'pageNumber': pagenumber
      }
    });
    this.service.getAll(this.pagenumber,5).subscribe((res:ProblemsModel)=>{
      console.log(res);
      this.problems = res.problem;
      this.totalPage = res.totalCount;
    });
  }

  ngOnInit() {

  }
  ngOnDestroy(): void {
    this.socproblem.disconnect();
  }

}
