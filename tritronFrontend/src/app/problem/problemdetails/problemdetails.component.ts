import { Component, OnInit } from '@angular/core';
import {ProblemViewModel} from '../../Models/ProblemView.model';
import {Largestrings} from '../../largestrings/largestrings';

@Component({
  selector: 'app-problemdetails',
  templateUrl: './problemdetails.component.html',
  styleUrls: ['./problemdetails.component.scss']
})
export class ProblemdetailsComponent implements OnInit {

  model:ProblemViewModel;
  constructor() {
    this.model = new ProblemViewModel();
    this.model.problemName = 'a problem';
    this.model.problemDescription = Largestrings.problemDescription;
  }

  ngOnInit() {
  }

}
