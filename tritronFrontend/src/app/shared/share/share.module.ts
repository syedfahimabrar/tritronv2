import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from '@angular/forms';
import {AngularEditorModule} from '@kolkov/angular-editor';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
      NgbModule,
      FormsModule
  ],
  exports: [CommonModule,NgbModule,FormsModule]
})
export class ShareModule { }
