import {Component, OnInit, ElementRef, OnDestroy} from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import {ActivatedRoute, Router} from '@angular/router';
import {CommonService} from '../common.service';
import {Observable, Subscription} from 'rxjs';
import {AuthService} from '../../services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {
    private toggleButton: any;
    private sidebarVisible: boolean;
    public subscription: Subscription;
    public tokenSubscription:Subscription;
    public profilepicsubscription;
    isTrans;
    token:string;
    profilepic:string;
    constructor(public location: Location, private element: ElementRef,
                public service: CommonService,private authService:AuthService,
                private helper: JwtHelperService) {
        this.sidebarVisible = false;
    }
    ngOnInit() {
        this.isTrans = false;
        const navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
        this.subscription =  this.service.isTrans.subscribe((isTrans) => { this.isTrans = isTrans;});
        this.tokenSubscription = this.authService.tok.subscribe((tok) => {this.token = tok;console.log("triggered");});
        this.profilepicsubscription = this.authService.propic.subscribe((pic)=>{this.profilepic = pic});
        if(this.profilepic == null)
            this.profilepic = this.helper.decodeToken(this.token).profilepic;
        //console.log(this.router.url);
    }
    timer(ms) {
        return new Promise(res => setTimeout(res, ms));
    }
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
    logout(){
        this.authService.logout();
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
