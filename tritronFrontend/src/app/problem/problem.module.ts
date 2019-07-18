import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProblemRoutingModule } from './problem-routing.module';
import { ProblemdetailsComponent } from './problemdetails/problemdetails.component';
import { ProblemsComponent } from './problems/problems.component';

@NgModule({
  declarations: [
      ProblemdetailsComponent,
      ProblemsComponent
  ],
  imports: [
    CommonModule,
    ProblemRoutingModule
  ]
})
export class ProblemModule { }
