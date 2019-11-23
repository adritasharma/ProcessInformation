import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CoreModule } from '../core/core.module';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { InitialsPipe } from './pipes/initials.pipe';
import { AdminPageHeaderComponent } from './components/admin-page-header/admin-page-header.component';
import { CustomInputTextComponent } from './components/inputs/custom-input-text/custom-input-text.component';
import { ChildFieldControlDirective } from './directives/ChildFieldControlDirective';

@NgModule({
  imports: [
    CommonModule,
    CoreModule
  ],
  declarations: [
    NavbarComponent,
    NotFoundComponent,
    InitialsPipe,
    AdminPageHeaderComponent,
    ChildFieldControlDirective,
    CustomInputTextComponent
  ],
  exports: [
    NavbarComponent,
    NotFoundComponent,
    InitialsPipe,
    AdminPageHeaderComponent,
    ChildFieldControlDirective,
    CustomInputTextComponent
  ]
})
export class SharedModule { }
