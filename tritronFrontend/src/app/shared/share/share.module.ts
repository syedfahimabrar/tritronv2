import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from '@angular/forms';
import {EscapeHtmlPipe} from '../../pipes/keep-html.pipe';
import {CovalentCodeEditorModule} from '@covalent/code-editor';

@NgModule({
  declarations: [
    EscapeHtmlPipe
  ],
  imports: [
    CommonModule,
      NgbModule,
      FormsModule,
      CovalentCodeEditorModule
  ],
  exports: [CommonModule,NgbModule,FormsModule,EscapeHtmlPipe,CovalentCodeEditorModule]
})
export class ShareModule { }
