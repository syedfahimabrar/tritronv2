import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {EscapeHtmlPipe} from '../../pipes/keep-html.pipe';
import {CovalentCodeEditorModule} from '@covalent/code-editor';
import {ComponentsModule} from '../../components/components.module';
import {NgxPaginationModule} from 'ngx-pagination';

@NgModule({
  declarations: [
    EscapeHtmlPipe
  ],
  imports: [
    CommonModule,
      NgbModule,
      FormsModule,
      CovalentCodeEditorModule,
    ReactiveFormsModule,
      NgxPaginationModule
  ],
  exports: [CommonModule,NgbModule,FormsModule,EscapeHtmlPipe,CovalentCodeEditorModule,ReactiveFormsModule,NgxPaginationModule]
})
export class ShareModule { }
