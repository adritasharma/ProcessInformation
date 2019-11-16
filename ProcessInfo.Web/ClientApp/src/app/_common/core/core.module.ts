import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgbModule,
    HttpClientModule
  ],
  declarations: [],
  exports: [
    RouterModule,
    FormsModule,
    HttpClientModule,
    NgbModule
  ]
})
export class CoreModule { }
