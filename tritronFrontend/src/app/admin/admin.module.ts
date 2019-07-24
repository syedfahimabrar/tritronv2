import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import {CreateproblemComponent} from './problem/createproblem/createproblem.component';
import {ShareModule} from '../shared/share/share.module';
import {AngularEditorModule} from '@kolkov/angular-editor';
import { EditproblemComponent } from './problem/editproblem/editproblem.component';
import {ComponentsModule} from '../components/components.module';
import {JwBootstrapSwitchNg2Module} from 'jw-bootstrap-switch-ng2';
import {ProblemService} from '../services/problem.service';
import { CreatecontestComponent } from './contest/createcontest/createcontest.component';

@NgModule({
  declarations: [
      CreateproblemComponent,
      EditproblemComponent,
      CreatecontestComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
      ShareModule,
    AngularEditorModule,
      ComponentsModule,
    JwBootstrapSwitchNg2Module

  ],
  providers:[ProblemService]
})
export class AdminModule { }
