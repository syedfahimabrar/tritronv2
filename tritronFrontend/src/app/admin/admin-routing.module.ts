import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CreateproblemComponent} from './problem/createproblem/createproblem.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path:'problem', children:[
          {path:'create',component:CreateproblemComponent}
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
