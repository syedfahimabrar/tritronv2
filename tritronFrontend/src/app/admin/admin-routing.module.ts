import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CreateproblemComponent} from './problem/createproblem/createproblem.component';
import {EditproblemComponent} from './problem/editproblem/editproblem.component';
import {CreatecontestComponent} from './contest/createcontest/createcontest.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path:'problem', children:[
          {path:'create',component:CreateproblemComponent},
          {path:'edit',component:EditproblemComponent}
        ]
      },
      {path:'contest',children:[
          {path:'create', component:CreatecontestComponent}
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
