import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import {CreateproblemComponent} from './problem/createproblem/createproblem.component';
import {ShareModule} from '../shared/share/share.module';
import {AngularEditorModule} from '@kolkov/angular-editor';
import { EditproblemComponent } from './problem/editproblem/editproblem.component';
import {ComponentsModule} from '../components/components.module';
import {JwBootstrapSwitchNg2Module} from 'jw-bootstrap-switch-ng2';
import {ProblemService} from '../_services/problem.service';
import { CreatecontestComponent } from './contest/createcontest/createcontest.component';
import {SortablejsModule} from 'angular-sortablejs';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {AsciPipe} from '../pipes/asci.pipe'
// @ts-ignore
@NgModule({
  declarations: [
      AsciPipe,
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
        SortablejsModule,
        JwBootstrapSwitchNg2Module,
        DragDropModule
    ],
  providers:[ProblemService]
})
export class AdminModule { }
