import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Largestrings} from '../../../largestrings/largestrings';

@Component({
  selector: 'app-createproblem',
  templateUrl: './createproblem.component.html',
  styleUrls: ['./createproblem.component.scss']
})
export class CreateproblemComponent implements OnInit {

  constructor() {
  }
  problemDescription:string;
  ngOnInit() {
      this.problemDescription = Largestrings.problemDescription;
      console.log(this.problemDescription);

  }
  save(){

  }

}
