import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { UserToursComponent } from './tours/user-tours/user-tours.component';
import { ProfileComponent } from './profile/profile.component';


export const userRoutes: Routes = [
    {
        path: '', component: UserComponent,
        children: [
            { path: '', component: UserToursComponent },
            { path: 'profile', component: ProfileComponent }
        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class UserRoutingModule {
}
