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
import { CustomInputSelectComponent } from './components/inputs/custom-input-text/custom-input-select/custom-input-select.component';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    DataTablesModule
  ],
  declarations: [
    ConfirmationDialogComponent,
    NavbarComponent,
    NotFoundComponent,
    InitialsPipe,
    AdminPageHeaderComponent,
    ChildFieldControlDirective,
    CustomInputTextComponent,
    CustomInputSelectComponent,
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
    CustomInputSelectComponent,
    ListActionsComponent
  ],
  entryComponents: [ ConfirmationDialogComponent ],
})
export class SharedModule { }
