import {Component, OnDestroy, OnInit} from '@angular/core';
import {CommonService} from '../../../shared/common.service';

@Component({
  selector: 'app-contestlistitem',
  templateUrl: './contestlistitem.component.html',
  styleUrls: ['./contestlistitem.component.scss']
})
export class ContestlistitemComponent implements OnInit, OnDestroy {

  constructor(private service: CommonService) { }

  ngOnInit() {
  }
  ngOnDestroy(): void {
  }

}
