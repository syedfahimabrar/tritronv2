import { Component, OnInit } from '@angular/core';
import {ProblemService} from '../../services/problem.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ProblemsModel} from '../../Models/problems.model';

@Component({
  selector: 'app-problems',
  templateUrl: './problems.component.html',
  styleUrls: ['./problems.component.scss']
})
export class ProblemsComponent implements OnInit {

  problems;
  public pagenumber=2;
  public totalPage=50;
  hello = 5;
  constructor(private service:ProblemService,private route:ActivatedRoute,private router:Router) {
    this.pagenumber =(this.route.snapshot.queryParams['pageNumber']==null?1:this.route.snapshot.queryParams['pageNumber']);
    this.service.getAll(this.pagenumber,5).subscribe((res:ProblemsModel)=>{
      console.log(res);
      this.problems = res.problem;
      this.totalPage = res.totalCount;
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

}
