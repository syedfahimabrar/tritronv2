import { Component, OnInit } from '@angular/core';
import {Subject} from 'rxjs';
import {ProblemService} from '../../../services/problem.service';
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-createcontest',
  templateUrl: './createcontest.component.html',
  styleUrls: ['./createcontest.component.scss']
})
export class CreatecontestComponent implements OnInit {

  problems;
  selectedProblems = new Set();
  query:string;
  contestCreateForm:FormGroup;
  constructor(private service:ProblemService,private fb:FormBuilder) {
    this.contestCreateForm = this.fb.group({
      name:['',Validators.required],
      startDate:['',Validators.required],
      startTime:['',Validators.required],
      endDate:['',Validators.required],
      endTime:['',Validators.required],
      backgroundImage:['',Validators.required],
      description:['',Validators.required],
      problems:this.fb.array([this.addProblems()])
    });
  }
  addProblems(){
    return this.fb.group({
      problemid:['',Validators.required]
    });
  }

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
