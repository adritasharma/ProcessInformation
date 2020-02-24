import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './home/landing/landing.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './_common/shared/components/not-found/not-found.component';
import { UserRouteGuard } from './_common/shared/guards/user-route-guard';
import { SignupComponent } from './signup/signup.component';


export const routes: Routes = [
    { path: '', component: LandingComponent },
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    {
        path: 'admin',
        loadChildren: './_modules/admin/admin.module#AdminModule',
      //  canActivate: [AppRouteGuard], data: { loginType: 'admin' }
    },
    {
        path: 'user',
        loadChildren: './_modules/user/user.module#UserModule',
        canActivate: [UserRouteGuard]
    },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    exports: [RouterModule]
})

export class AppRoutingModule {
}
