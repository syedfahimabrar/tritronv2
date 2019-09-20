import {Component, OnInit, ViewEncapsulation,Renderer2} from '@angular/core';
import {Subject} from 'rxjs';
import {LoaderService} from '../../_services/loader.service';
declare const require: any;
@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {

  isLoading: Subject<boolean> = this.loaderService.isLoading;
  constructor(private loaderService: LoaderService) { }
  ngOnInit() {
    console.log(this.isLoading);
  }
  ngOnDestroy() {
  }

}
