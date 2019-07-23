import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Largestrings} from '../../../largestrings/largestrings';
import {FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ProblemService} from '../../../services/problem.service';
import {JwtHelperService} from '@auth0/angular-jwt';
import {ProblemcreateModel} from '../../../Models/problemcreate.model';
import {ToastrService} from 'ngx-toastr';
import {AngularEditorConfig} from '@kolkov/angular-editor';
import {Router} from '@angular/router';

@Component({
  selector: 'app-createproblem',
  templateUrl: './createproblem.component.html',
  styleUrls: ['./createproblem.component.scss']
})
export class CreateproblemComponent implements OnInit {

  infiletext=[];
  outfiletext=[];
  totaltest;
  model:ProblemcreateModel;
  problemCreateForm:FormGroup;
  problemDescription:string;
  constructor(private fb:FormBuilder,private problemService:ProblemService,
              private router:Router ,private toastr:ToastrService,private jwtHelper:JwtHelperService) {
    this.problemDescription = Largestrings.problemDescription;
    this.problemCreateForm = this.fb.group({
      problemName:['',Validators.required],
      isPublished:['',Validators.required],
      problemAuthorId:['',Validators.required],
      authorName:['',Validators.required],
      problemDescription:['',Validators.required],
      Tests: this.fb.array([this.addsubform()])
    });
    this.problemCreateForm.controls['problemDescription'].setValue(this.problemDescription);
    this.problemCreateForm.patchValue(
        {
          isPublished:false
          ,problemAuthorId:this.jwtHelper.decodeToken(localStorage.getItem('token')).UserID
          ,authorName:this.jwtHelper.decodeToken(localStorage.getItem('token')).unique_name
        });
    /*this.problemCreateForm = new FormGroup({
      problemName: new FormControl(),
      problemDescription: new FormControl(),
      Tests: new FormGroup({
        inputTest: new FormControl(),
        outputTest: new FormControl()
      })
    });*/
  }

  ngOnInit() {
      this.totaltest = 5;
  }
  save(){
    console.log('saved');
    console.log(this.problemCreateForm.value);
    this.model = new ProblemcreateModel();
    this.model.problemName = this.problemCreateForm.get('problemName').value;
    this.model.problemDescription = this.problemCreateForm.get('problemDescription').value;
    this.model.problemAuthorId = this.problemCreateForm.get('problemAuthorId').value;
    this.model.authorName = this.problemCreateForm.get('authorName').value;
    this.model.isPublished = this.problemCreateForm.get('isPublished').value;
    this.model.inputTest = this.infiletext;
    this.model.outputTest = this.outfiletext;
    //console.log(this.problemCreateForm.value);

    //console.log((<FormArray>this.problemCreateForm.get('Tests')).at(0).value);
    this.problemService.submitProblem(this.model).subscribe((res:ProblemcreateModel)=>{
      this.toastr.success(res.id+" created!!","problem "+res.id);
      this.router.navigateByUrl('/problem/'+res.id);
    },(error)=>{
      console.log(error);
      this.toastr.error(error);
    });
  }
  fileUpload(event,i,ty:string) {
    var reader = new FileReader();
    var m = reader.readAsText(event.srcElement.files[0]);
    if(event.srcElement.files[0].size>256*1024*1024){
      this.toastr.info("max size is 256kb");
      event.srcElement.value = '';
      return;
    }
    var me = this;
    reader.onload = function () {
      if(ty==='in')
        me.infiletext[i] = reader.result;
      else
        me.outfiletext[i] = reader.result;
    }
  }
  removeSkillButtonClick(i){
    console.log('clicked');
    (<FormArray>this.problemCreateForm.get('Tests')).removeAt(i);
    console.log(this.infiletext);
    console.log(this.outfiletext);
    if(this.infiletext[i] != 'undefined')
      this.infiletext.splice(i,1);
    if(this.outfiletext[i] != 'undefined')
      this.outfiletext.splice(i,1);
    console.log(this.infiletext);
    console.log(this.outfiletext);
  }
  addsubform(){
    return this.fb.group({
      inputTest:['',Validators.required],
      outputTest:['',Validators.required]
    });

  }
  addtest(){
    (<FormArray>this.problemCreateForm.get('Tests')).push(this.addsubform());
  }
  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    sanitize: false,
    toolbarPosition: 'top',
    defaultFontName: 'Arial',
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ]
  };

}
