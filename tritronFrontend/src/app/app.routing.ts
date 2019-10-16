import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ComponentsComponent } from './components/components.component';
import { LandingComponent } from './examples/landing/landing.component';
import { ProfileComponent } from './examples/profile/profile.component';
import { NucleoiconsComponent } from './components/nucleoicons/nucleoicons.component';
import {HomeComponent} from './comps/home/home.component';
import {ContestsComponent} from './comps/contests/contests.component';
import {RegisterComponent} from './comps/register/register.component';
import {LoginComponent} from './comps/login/login.component';
import {NgbdModalBasic} from './components/modal/modal.component';
import {ExamplesComponent} from './examples/examples.component';
import {LoaderComponent} from './shared/loader/loader.component';
import {ContestComponent} from './comps/contests/contest/contest.component';

const routes: Routes = [
    // { path: '', redirectTo: 'index', pathMatch: 'full' },
    { path: '', component: HomeComponent},
    { path: 'contest/:id', component: ContestComponent},
    { path: 'contests' , component: ContestsComponent},
    { path: 'index',                component: ComponentsComponent },
    { path: 'register',          component: RegisterComponent },
    { path: 'login',          component: LoginComponent },
    { path: 'profile', component: ProfileComponent},
    { path: 'profile:id', component: ProfileComponent},
    { path: 'nucleoicons',          component: NucleoiconsComponent },
    { path: 'examples/landing',     component: LandingComponent },
    { path: 'examples', component: ComponentsComponent},
    { path: 'loader', component: LoaderComponent},
    // { path: 'examples/profile',     component: ProfileComponent }
    { path: 'admin', loadChildren: './admin/admin.module#AdminModule'},
    { path: 'problem', loadChildren: './problem/problem.module#ProblemModule'}
];

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        RouterModule.forRoot(routes)
    ],
    exports: [
    ],
})
export class AppRoutingModule { }
