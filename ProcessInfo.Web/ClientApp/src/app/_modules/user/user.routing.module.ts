import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { ProfileComponent } from './profile/profile.component';
import { SaveApplicationComponent } from './pages/application/save-application/save-application.component';
import { ListApplicationComponent } from './pages/application/list-application/list-application.component';
import { ViewApplicationComponent } from './pages/application/view-application/view-application.component';
import { UserDashboardComponent } from './pages/application/user-dashboard/user-dashboard.component';
import { ListPortsComponent } from './pages/application/list-ports/list-ports.component';

export const userRoutes: Routes = [
    {
        path: '', component: UserComponent,
        children: [
            { path: '', component: UserDashboardComponent },
            { path: 'dashboard', component: UserDashboardComponent },
            { path: 'profile', component: ProfileComponent },

            { path: 'application/save', component: SaveApplicationComponent },
            { path: 'application/list', component: ListApplicationComponent },
            { path: 'application/view/:id', component: ViewApplicationComponent },
            { path: 'application/edit/:id', component: SaveApplicationComponent },

            { path: 'ports', component: ListPortsComponent },

        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class UserRoutingModule {
}
