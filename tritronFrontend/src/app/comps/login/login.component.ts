import { Component, OnInit } from '@angular/core';
import {UserRegisterModel} from '../../Models/UserRegisterModel';
import {AuthService} from '../../services/auth.service';
import {ToastrService} from 'ngx-toastr';

import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: UserRegisterModel;
  constructor(private authservice: AuthService,private toastservice:ToastrService,private helper: JwtHelperService) {
    this.model = new UserRegisterModel();
  }

  ngOnInit() {
    let body = document.getElementsByTagName('body')[0];
    body.classList.add('login-page');

    let navbar = document.getElementsByTagName('nav')[0];
    navbar.classList.add('navbar-transparent');
  }
  ngOnDestroy() {
    let body = document.getElementsByTagName('body')[0];
    body.classList.remove('login-page');

    let navbar = document.getElementsByTagName('nav')[0];
    navbar.classList.remove('navbar-transparent');
  }
  timer(ms) {
    return new Promise(res => setTimeout(res, ms));
  }
  login(loginForm: any) {
    console.log("logged in");
    this.authservice.login(this.model).subscribe(
        (res) => {
          if(res.succeeded){
            localStorage.setItem('token',res.token);
            var tok = localStorage.getItem('token');
            this.authservice.loggedin(tok);
          }
        },
        (error) =>{
          console.log(error);
          this.toastservice.error(error.error.error,'Error');
        }
    );
  }

}
