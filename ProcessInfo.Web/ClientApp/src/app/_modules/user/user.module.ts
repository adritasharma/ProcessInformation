import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { RouterModule } from '@angular/router';
import { userRoutes } from './user.routing.module';
import { CoreModule } from 'src/app/_common/core/core.module';
import { UserToursComponent } from './tours/user-tours/user-tours.component';
import { SharedModule } from 'src/app/_common/shared/shared.module';
import { ProfileComponent } from './profile/profile.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(userRoutes),
    CoreModule,
    SharedModule
  ],
  declarations: [
    UserComponent,
    ProfileComponent,
    UserToursComponent
  ]
})
export class UserModule { }
