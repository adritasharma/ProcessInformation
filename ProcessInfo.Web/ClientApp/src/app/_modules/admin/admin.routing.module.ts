import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';
import { SaveEnvironmentComponent } from './pages/environment/save-environment/save-environment.component';
import { ListEnvironmentComponent } from './pages/environment/list-environment/list-environment.component';



export const adminRoutes: Routes = [
    {
        path: '', component: AdminComponent,
        children: [
            { path: '', component: AdminDashboardComponent },
            { path: 'environment', component: ListEnvironmentComponent },
            { path: 'environment/save', component: SaveEnvironmentComponent },
            { path: 'environment/edit/:id', component: SaveEnvironmentComponent }
        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class AdminRoutingModule {
}
