import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';



export const adminRoutes: Routes = [
    {
        path: '', component: AdminComponent,
        children: [
            { path: '', component: AdminDashboardComponent },
        ]
    }
];

@NgModule({
    exports: [RouterModule]
})

export class AdminRoutingModule {
}
