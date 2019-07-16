import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from '@angular/forms';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {EscapeHtmlPipe} from '../../pipes/keep-html.pipe';

@NgModule({
  declarations: [
    EscapeHtmlPipe
  ],
  imports: [
    CommonModule,
      NgbModule,
      FormsModule
  ],
  exports: [CommonModule,NgbModule,FormsModule,EscapeHtmlPipe]
})
export class ShareModule { }
