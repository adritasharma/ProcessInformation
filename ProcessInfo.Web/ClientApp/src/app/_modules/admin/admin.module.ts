import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { adminRoutes } from './admin.routing.module';
import { RouterModule } from '@angular/router';
import { CoreModule } from 'src/app/_common/core/core.module';
import { SharedModule } from 'src/app/_common/shared/shared.module';
import { AdminSidebarComponent } from './admin-sidebar/admin-sidebar.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';
import { SaveEnvironmentComponent } from './pages/environment/save-environment/save-environment.component';
import { ListEnvironmentComponent } from './pages/environment/list-environment/list-environment.component';
import { ListApplicationTypesComponent } from './pages/application-types/list-application-types/list-application-types.component';
import { SaveApplicationTypeComponent } from './pages/application-types/save-application-type/save-application-type.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(adminRoutes),
    CoreModule,
    SharedModule
  ],
  declarations: [
    AdminComponent,
    AdminSidebarComponent,
    AdminDashboardComponent,
    SaveEnvironmentComponent,
    ListEnvironmentComponent,
    ListApplicationTypesComponent,
    SaveApplicationTypeComponent
  ]
})
export class AdminModule { }
