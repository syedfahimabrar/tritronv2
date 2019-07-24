import { Component, OnInit } from '@angular/core';
import {Subject} from 'rxjs';
import {ProblemService} from '../../../services/problem.service';

@Component({
  selector: 'app-createcontest',
  templateUrl: './createcontest.component.html',
  styleUrls: ['./createcontest.component.scss']
})
export class CreatecontestComponent implements OnInit {

  problems;
  selectedProblems = new Set();
  query:string;
  constructor(private service:ProblemService) { }

  ngOnInit() {
    this.service.getsearched(this.query).subscribe((res)=>{
      console.log("triggered");
      console.log(res);
      this.problems = res;
    });
  }
  search($event) {
    let q = $event.target.value;
    console.log(q);
    this.query = q;
    this.service.getsearched(this.query).subscribe((res)=>{
      console.log("triggered");
      console.log(res);
      this.problems = res;
    });
  }

  onSelect(id){
      console.log(id);
      this.selectedProblems.add(id);
  }

}
