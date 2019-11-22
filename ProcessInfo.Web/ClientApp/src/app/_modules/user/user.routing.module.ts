import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { ProfileComponent } from './profile/profile.component';
import { SaveApplicationComponent } from './pages/application/save-application/save-application.component';


export const userRoutes: Routes = [
    {
        path: '', component: UserComponent,
        children: [
            // { path: '', component: ProfileComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'application/save', component: SaveApplicationComponent },
            { path: 'application/save', component: ProfileComponent }
        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class UserRoutingModule {
}
