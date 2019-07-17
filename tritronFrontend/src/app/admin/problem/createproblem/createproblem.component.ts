import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Largestrings} from '../../../largestrings/largestrings';
import {FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-createproblem',
  templateUrl: './createproblem.component.html',
  styleUrls: ['./createproblem.component.scss']
})
export class CreateproblemComponent implements OnInit {

  infiletext=[];
  outfiletext=[];
  totaltest;
  problemCreateForm:FormGroup;
  problemDescription:string;
  constructor(private fb:FormBuilder) {
    this.problemDescription = Largestrings.problemDescription;
    this.problemCreateForm = this.fb.group({
      problemName:['',Validators.required],
      problemDescription:['',Validators.required],
      Tests: this.fb.array([this.addsubform()])
    });
    this.problemCreateForm.controls['problemDescription'].setValue(this.problemDescription);
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
    console.log((<FormArray>this.problemCreateForm.get('Tests')).at(0).value);
  }
  fileUpload(event,i,ty:string) {
    var reader = new FileReader();
    var m = reader.readAsText(event.srcElement.files[0]);
    var me = this;
    reader.onload = function () {
      console.log(reader.result);
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

}
