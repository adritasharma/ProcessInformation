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
import { CustomInputRadioComponent } from './components/inputs/custom-input-radio/custom-input-radio.component';
import { CustomChartComponent } from './components/custom-chart/custom-chart.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { CustomInputChipComponent } from './components/inputs/custom-input-chip/custom-input-chip.component';
import { TagInputModule } from 'ngx-chips';
import { CustomInputFileComponent } from './components/inputs/custom-input-file/custom-input-file.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    DataTablesModule,
    GoogleChartsModule,
    TagInputModule
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
    CustomInputRadioComponent,
    CustomInputChipComponent,
    ListActionsComponent,
    CustomChartComponent,
    CustomInputFileComponent
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
    CustomInputRadioComponent,
    CustomInputChipComponent,
    ListActionsComponent,
    CustomChartComponent,
    CustomInputFileComponent
  ],
  entryComponents: [ ConfirmationDialogComponent ],
})
export class SharedModule { }
