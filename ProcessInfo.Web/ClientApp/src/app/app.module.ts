import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { SharedModule } from './_common/shared/shared.module';
import { CoreModule } from './_common/core/core.module';

import { RouterModule } from '@angular/router';
import { routes } from './app.routing.module';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LandingComponent } from './home/landing/landing.component';
import { AboutComponent } from './home/about/about.component';

import { HttpInterceptorService } from './_common/core/services/http-interceptor.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        LandingComponent,
        AboutComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        CoreModule,
        SharedModule,
        RouterModule.forRoot(routes),
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpInterceptorService,
            multi: true
        }
    ],
    bootstrap: [
        AppComponent
    ],
    exports: [RouterModule]
})
export class AppModule { }
