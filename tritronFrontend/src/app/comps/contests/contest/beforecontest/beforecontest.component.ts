import {Component, Input, OnInit} from '@angular/core';
import {timer} from 'rxjs';

@Component({
  selector: 'app-beforecontest',
  templateUrl: './beforecontest.component.html',
  styleUrls: ['./beforecontest.component.scss']
})
export class BeforecontestComponent implements OnInit {

  @Input() contest;
  days:number;
  hours:number;
  minutes:number;
  seconds:number;
  t:number;
  countDownDate;
  constructor() { }

  ngOnInit() {
    this.countDownDate = new Date(this.contest.startTime).getTime();
    timer(1, 1000).subscribe(x=>{
      this.countdown();
    });
  }
  countdown(){
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = this.countDownDate - now;

    // Time calculations for days, hours, minutes and seconds
    this.days = Math.floor(distance / (1000 * 60 * 60 * 24));
    this.hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    this.minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    this.seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Display the result in the element with id="demo"


    // If the count down is finished, write some text

  }

}
