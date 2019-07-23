import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {EscapeHtmlPipe} from '../../pipes/keep-html.pipe';
import {CovalentCodeEditorModule} from '@covalent/code-editor';
import {ComponentsModule} from '../../components/components.module';

@NgModule({
  declarations: [
    EscapeHtmlPipe
  ],
  imports: [
    CommonModule,
      NgbModule,
      FormsModule,
      CovalentCodeEditorModule,
    ReactiveFormsModule
  ],
  exports: [CommonModule,NgbModule,FormsModule,EscapeHtmlPipe,CovalentCodeEditorModule,ReactiveFormsModule]
})
export class ShareModule { }
