import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';
import { SaveEnvironmentComponent } from './pages/environment/save-environment/save-environment.component';
import { ListEnvironmentComponent } from './pages/environment/list-environment/list-environment.component';
import { ListApplicationTypeComponent } from './pages/application-types/list-application-types/list-application-types.component';
import { SaveApplicationTypeComponent } from './pages/application-types/save-application-type/save-application-type.component';
import { ListUserComponent } from './pages/users/list-user/list-user.component';
import { BulkUploadUsersComponent } from './pages/users/list-user/bulk-upload-users/bulk-upload-users.component';
import { SaveUserComponent } from './pages/users/list-user/save-user/save-user.component';



export const adminRoutes: Routes = [
    {
        path: '', component: AdminComponent,
        children: [
            { path: '', component: AdminDashboardComponent },
            { path: 'environment', component: ListEnvironmentComponent },
            { path: 'environment/save', component: SaveEnvironmentComponent },
            { path: 'environment/edit/:id', component: SaveEnvironmentComponent },

            { path: 'application-type', component: ListApplicationTypeComponent },
            { path: 'application-type/save', component: SaveApplicationTypeComponent },
            { path: 'application-type/edit/:id', component: SaveApplicationTypeComponent },

            { path: 'user', component: ListUserComponent },
            { path: 'user/bulk-upload', component: BulkUploadUsersComponent },
            { path: 'user/save', component: SaveUserComponent },
            { path: 'user/edit/:id', component: SaveUserComponent }
        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class AdminRoutingModule {
}
