import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Largestrings} from '../../../largestrings/largestrings';
import {FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-createproblem',
  templateUrl: './createproblem.component.html',
  styleUrls: ['./createproblem.component.scss']
})
export class CreateproblemComponent implements OnInit {

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

  filetext:string;
  ngOnInit() {
      console.log(this.problemDescription);
      this.totaltest = 5;
  }
  save(){

  }
  fileUpload(event) {
    var reader = new FileReader();
    reader.readAsText(event.srcElement.files[0]);

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
