import { Component, OnInit } from '@angular/core';
import {CommonService} from '../../shared/common.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  data : Date = new Date();
  focus;
  focus1;

  constructor(private service:CommonService) {
    this.service.changeIsTrans(true);
  }

  ngOnInit() {
    //this.service.changeIsTrans(true);
  }
  ngOnDestroy(){

    this.service.changeIsTrans(false);
    console.log("triggered");
  }


}
