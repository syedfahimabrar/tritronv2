import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // this is needed!
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { ExamplesModule } from './examples/examples.module';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './comps/home/home.component';
import { ContestsComponent } from './comps/contests/contests.component';
import { ContestlistitemComponent } from './comps/contests/contestlistitem/contestlistitem.component';
import { RegisterComponent } from './comps/register/register.component';
import {HttpClientModule} from '@angular/common/http';
import {ToastrModule} from 'ngx-toastr';
import {LoginComponent} from './comps/login/login.component';
import { ProfileComponent } from './comps/profile/profile.component';
import { FooterComponent } from './comps/footer/footer.component';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {EscapeHtmlPipe} from './pipes/keep-html.pipe';

export function tokenGetter() {
    return localStorage.getItem("token");
}

@NgModule({
    declarations: [
        AppComponent,
        NavbarComponent,
        HomeComponent,
        ContestsComponent,
        ContestlistitemComponent,
        RegisterComponent,
        LoginComponent,
        ProfileComponent,
        FooterComponent
    ],
    imports: [
        BrowserAnimationsModule,
        NgbModule.forRoot(),
        FormsModule,
        RouterModule,
        AngularEditorModule,
        AppRoutingModule,
        ComponentsModule,
        ExamplesModule,
        HttpClientModule,
        ToastrModule.forRoot(),
        ReactiveFormsModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                skipWhenExpired: true,
                whitelistedDomains: ["example.com"],
                blacklistedRoutes: ["example.com/examplebadroute/"]
            }
        })
    ],
    exports:[NgbModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
