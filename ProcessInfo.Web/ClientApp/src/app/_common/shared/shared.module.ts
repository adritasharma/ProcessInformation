import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CoreModule } from '../core/core.module';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { InitialsPipe } from './pipes/initials.pipe';
import { AdminPageHeaderComponent } from './components/admin-page-header/admin-page-header.component';
import { CustomInputTextComponent } from './components/inputs/custom-input-text/custom-input-text.component';
import { ChildFieldControlDirective } from './directives/ChildFieldControlDirective';
import { DataTablesModule } from 'angular-datatables';
import { ListActionsComponent } from './components/list-actions/list-actions.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    DataTablesModule
  ],
  declarations: [
    NavbarComponent,
    NotFoundComponent,
    InitialsPipe,
    AdminPageHeaderComponent,
    ChildFieldControlDirective,
    CustomInputTextComponent,
    ListActionsComponent
  ],
  exports: [
    DataTablesModule,
    NavbarComponent,
    NotFoundComponent,
    InitialsPipe,
    AdminPageHeaderComponent,
    ChildFieldControlDirective,
    CustomInputTextComponent,
    ListActionsComponent
  ]
})
export class SharedModule { }
