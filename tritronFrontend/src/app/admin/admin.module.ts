import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import {CreateproblemComponent} from './problem/createproblem/createproblem.component';
import {ShareModule} from '../shared/share/share.module';
import {AngularEditorModule} from '@kolkov/angular-editor';
import { EditproblemComponent } from './problem/editproblem/editproblem.component';
import {ComponentsModule} from '../components/components.module';

@NgModule({
  declarations: [
      CreateproblemComponent,
      EditproblemComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
      ShareModule,
    AngularEditorModule,
      ComponentsModule
  ]
})
export class AdminModule { }
