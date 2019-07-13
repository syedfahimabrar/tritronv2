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
import {ProblemsComponent} from './comps/problems/problems.component';
import {RegisterComponent} from './comps/register/register.component';
import {LoginComponent} from './comps/login/login.component';
import {CreateproblemComponent} from './comps/problems/createproblem/createproblem.component';

const routes: Routes =[
    // { path: '', redirectTo: 'index', pathMatch: 'full' },
    { path: '', component: HomeComponent},
    { path: 'contests' , component: ContestsComponent},
    { path: 'index',                component: ComponentsComponent },
    { path: 'problems',          component: ProblemsComponent },
    { path: 'register',          component: RegisterComponent },
    { path: 'login',          component: LoginComponent },
    { path: 'profile', component:ProfileComponent},
    { path: 'profile:id', component:ProfileComponent},
    { path: 'nucleoicons',          component: NucleoiconsComponent },
    { path: 'examples/landing',     component: LandingComponent },
    //{ path: 'examples/profile',     component: ProfileComponent }
    {
        path: 'admin',
        children: [
            { path:'createproblem',  component:CreateproblemComponent}
        ]
    }
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
