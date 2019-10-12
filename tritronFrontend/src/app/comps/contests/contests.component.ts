import { Component, OnInit } from '@angular/core';
import {ContestService} from '../../_services/contest.service';
import {ProblemsModel} from '../../_Models/problems.model';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-contests',
  templateUrl: './contests.component.html',
  styleUrls: ['./contests.component.scss']
})
export class ContestsComponent implements OnInit {

  contests;
  totalPage ;
  pagenumber = 1;
  constructor(private service:ContestService,private router:Router,
              private route:ActivatedRoute) {
    this.pagenumber =(this.route.snapshot.queryParams['pageNumber']==null?1:this.route.snapshot.queryParams['pageNumber']);
    this.loadPage(this.pagenumber);
  }
  loadPage(pagenumber){
    this.router.navigate([], {
      queryParams: {
        'pageNumber': pagenumber
      }
    });
    this.service.GetAll(this.pagenumber).subscribe((res:{contests,total})=>{
      console.log(res);
      this.contests = res.contests;
      this.totalPage = res.total;
    });
  }
  ngOnInit() {
  }
}
