import { Component, OnInit } from '@angular/core';
import {UserRegisterModel} from '../../_Models/UserRegisterModel';
import {AuthService} from '../../_services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {async} from 'q';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  data : Date = new Date();
  focus;
  focus1;

  model: UserRegisterModel;
  constructor(private authservice: AuthService,private toastservice:ToastrService) {
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
  register(registerForm: any) {
    console.log(this.model);
    this.authservice.register(this.model).subscribe(
        (res:any) => {
          if(res.succeeded){
            console.log("hello");
            this.toastservice.success('User has been registered successfully','Success');
            registerForm.reset();
          }else{
            console.log("tello");
            console.log(res.errors);
            res.errors.forEach(element => {

            });
          }
        },
        async err => {
          let errors = err.error.errors;
          for( let er of errors)
          {
            this.toastservice.error(er.description,er.code);
            await this.timer(1000);
            console.log(er.code);
          }
        }
    );
  }

}
