import { Component, OnInit } from '@angular/core';
import {Subject} from 'rxjs';
import {ProblemService} from '../../../services/problem.service';
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AngularEditorConfig} from '@kolkov/angular-editor';
import {Largestrings} from '../../../largestrings/largestrings';
import {ModalDismissReasons, NgbDate, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {forEach} from '@angular/router/src/utils/collection';
import {Time} from '@angular/common';
import {CreateContestModel} from '../../../Models/CreateContest.model';
import {ContestService} from '../../../services/contest.service';
import {toInteger} from '@ng-bootstrap/ng-bootstrap/util/util';
import {NgbTime} from '@ng-bootstrap/ng-bootstrap/timepicker/ngb-time';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-createcontest',
  templateUrl: './createcontest.component.html',
  styleUrls: ['./createcontest.component.scss']
})
export class CreatecontestComponent implements OnInit {

  sd:NgbDate;
  st:NgbTime;
  ed:NgbDate;
  et:NgbTime;
  model:CreateContestModel;
  closeResult: string;
  problems;
  selectedProblems = new Set();
  selectedProblemsId = new Set();
  query:string;
  contestCreateForm:FormGroup;
  constructor(private toastr:ToastrService,private conservice:ContestService,private proservice:ProblemService,private fb:FormBuilder,private modalService: NgbModal) {
    this.contestCreateForm = this.fb.group({
      name:['',Validators.required],
      startDate:['',Validators.required],
      startTime:['',Validators.required],
      endDate:['',Validators.required],
      endTime:['',Validators.required],
      backgroundImage:['',Validators.required],
      description:['',Validators.required]
    });
  }
  addProblems(){
    return this.fb.group({
      problemid:['',Validators.required]
    });
  }
  save(){
    this.sd = this.contestCreateForm.get('startDate').value;
    this.st = this.contestCreateForm.get('startTime').value;
    this.ed = this.contestCreateForm.get('endDate').value;
    this.et = this.contestCreateForm.get('endTime').value;
    var start = this.sd.day+'/'+this.sd.month+'/'+this.sd.year+' '+this.st.hour+':'+this.st.minute+':'+this.st.second;
        /*string.concat(sd,' ',st);*/
    var end = this.ed.day+'/'+this.ed.month+'/'+this.ed.year+' '+this.et.hour+':'+this.et.minute+':'+this.et.second;
    this.model = new CreateContestModel();
    this.model.Name = this.contestCreateForm.get('name').value;
    this.model.StartTime = start;
    this.model.EndTime = end;
    this.model.BackgroundImage = this.contestCreateForm.get('backgroundImage').value;
    this.model.Description = this.contestCreateForm.get('description').value;
    this.model.Problems = Array.from(this.selectedProblemsId);
    console.log(this.model);
    this.conservice.AddContest(this.model).subscribe((res:CreateContestModel) =>{
      console.log(res);
      this.toastr.success("Contest no "+res.id+" created succesfully","Created");
    },(error) => {
      console.log(error);
      this.toastr.error(error.error.error,"Multiple Problem Error");
    });
  }

  ngOnInit() {
    this.proservice.getsearched(this.query).subscribe((res)=>{
      console.log("triggered");
      console.log(res);
      this.problems = res;
    });
    this.contestCreateForm.patchValue({
      description:Largestrings.contestDescription
    });
  }
  search($event) {
    let q = $event.target.value;
    console.log(q);
    this.query = q;
    this.proservice.getsearched(this.query).subscribe((res)=>{
      console.log("triggered");
      console.log(res);
      this.problems = res;
    });
  }
  removeproblem(problem){
    this.selectedProblems.delete(problem);
    this.selectedProblemsId.delete(problem.id);
  }
  onSelect(p){
      console.log(p);
      this.selectedProblems.add(p);
      this.selectedProblemsId.add(p.id);
      this.contestCreateForm.patchValue({
        problems:this.selectedProblems
      })
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
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
  open(content, type, modalDimension) {
    if (modalDimension === 'sm' && type === 'modal_mini') {
      this.modalService.open(content, { windowClass: 'modal-mini modal-primary', size: 'sm' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    } else if (modalDimension == undefined && type === 'Login') {
      this.modalService.open(content, { windowClass: 'modal-login modal-primary' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    } else {
      this.modalService.open(content).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }

  }

}
