import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { RouterModule } from '@angular/router';
import { userRoutes } from './user.routing.module';
import { CoreModule } from 'src/app/_common/core/core.module';
import { SharedModule } from 'src/app/_common/shared/shared.module';
import { ProfileComponent } from './profile/profile.component';
import { SaveApplicationComponent } from './pages/application/save-application/save-application.component';
import { UserSidebarComponent } from './user-sidebar/user-sidebar.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(userRoutes),
    CoreModule,
    SharedModule
  ],
  declarations: [
    UserComponent,
    UserSidebarComponent,
    ProfileComponent,
    SaveApplicationComponent
  ]
})
export class UserModule { }
