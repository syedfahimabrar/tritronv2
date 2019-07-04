import {Component, OnInit, ElementRef, OnDestroy} from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import {ActivatedRoute, Router} from '@angular/router';
import {CommonService} from '../common.service';
import {Observable, Subscription} from 'rxjs';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {
    private toggleButton: any;
    private sidebarVisible: boolean;
    public subscription: Subscription;
    isTrans;
    constructor(public location: Location, private element: ElementRef, public service: CommonService) {
        this.sidebarVisible = false;

    }
    ngOnInit() {
        this.isTrans = false;
        const navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
      this.subscription =  this.service.isTrans.subscribe((isTrans) => { this.isTrans = isTrans;});
        //console.log(this.router.url);
    }
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

    sidebarOpen() {
        const toggleButton = this.toggleButton;
        const html = document.getElementsByTagName('html')[0];
        setTimeout(function(){
            toggleButton.classList.add('toggled');
        }, 500);
        html.classList.add('nav-open');

        this.sidebarVisible = true;
    };
    sidebarClose() {
        const html = document.getElementsByTagName('html')[0];
        // console.log(html);
        this.toggleButton.classList.remove('toggled');
        this.sidebarVisible = false;
        html.classList.remove('nav-open');
    };
    sidebarToggle() {
        // const toggleButton = this.toggleButton;
        // const body = document.getElementsByTagName('body')[0];
        if (this.sidebarVisible === false) {
            this.sidebarOpen();
        } else {
            this.sidebarClose();
        }
    };
  
    // isDocumentation() {
    //     var titlee = this.location.prepareExternalUrl(this.location.path());
    //     if( titlee === '/documentation' ) {
    //         return true;
    //     }
    //     else {
    //         return false;
    //     }
    // }
}
