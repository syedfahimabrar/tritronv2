import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CreateproblemComponent} from '../admin/problem/createproblem/createproblem.component';
import {ProblemsComponent} from './problems/problems.component';
import {ProblemdetailsComponent} from './problemdetails/problemdetails.component';
import {ShareModule} from '../shared/share/share.module';

const routes: Routes = [
  {
    path: '',
    children: [ {path:'',children:[
        { path: '', component:ProblemsComponent },
        { path: ':id', component: ProblemdetailsComponent }
      ]}

    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [
      RouterModule,
      ShareModule
  ]
})
export class ProblemRoutingModule { }
