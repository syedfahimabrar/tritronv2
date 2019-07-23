import { Component, OnInit } from '@angular/core';
import {ProblemViewModel} from '../../Models/ProblemView.model';
import {Largestrings} from '../../largestrings/largestrings';
import {Language} from '../../Models/Language';
import {SubmitCodeModel} from '../../Models/SubmitCode.model';
import {AuthService} from '../../services/auth.service';
import {tokenGetter} from '../../app.module';
import {promise} from 'selenium-webdriver';
import delayed = promise.delayed;
import {JwtHelperService} from '@auth0/angular-jwt';
import {ActivatedRoute} from '@angular/router';
import {ProblemService} from '../../services/problem.service';

@Component({
  selector: 'app-problemdetails',
  templateUrl: './problemdetails.component.html',
  styleUrls: ['./problemdetails.component.scss']
})
export class ProblemdetailsComponent implements OnInit {

  model:ProblemViewModel;
  submitcode:SubmitCodeModel;
  language;
  token:string;
  username:string;
  loggedin:boolean;
  constructor(auth:AuthService,helper:JwtHelperService,
              private service:ProblemService,private route:ActivatedRoute) {
    this.model = new ProblemViewModel();
    service.getProblem(this.route.snapshot.paramMap.get('id')).subscribe((res:ProblemViewModel)=>{
      console.log(res);
      this.model = res;
    },(error)=>{
      console.log(error);
    });
    console.log(this.model.problemDescription);
    this.language = Language.language;

    auth.isloggedin.subscribe(log => {
      this.loggedin = log;
      console.log('log is '+this.loggedin);
      if(this.loggedin){
        this.username = helper.decodeToken(this.token).unique_name;
      }

    });
    auth.token.subscribe(tok => this.token = tok);
    console.log(this.token);
    this.submitcode = new SubmitCodeModel();
  }

  ngOnInit() {
  }

}
