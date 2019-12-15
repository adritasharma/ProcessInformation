import { Component, OnInit, ViewChild } from '@angular/core';
import { ApplicationService } from '../application.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Application } from 'src/app/_common/shared/models/application.model';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';
@Component({
  selector: 'app-list-application',
  templateUrl: './list-application.component.html',
  styleUrls: ['./list-application.component.css']
})
export class ListApplicationComponent implements OnInit {


  constructor(private _applicationService: ApplicationService, private router: Router) { }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;
  componentHeaderData: any
  status: string = "Active"
  allApplications: Application[] = []

  ngOnInit() {
    this.componentHeaderData = {
      Title: "Applications",
      AddRouterLink: ['/admin/manager/vendors/Add'],
      IsListPage: true
    }

    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: false,
      ajax: (dataTablesParameters: any, callback) => {
       // dataTablesParameters.FilterType = this.status;
        console.log("j")
        that._applicationService.getAllApplications(dataTablesParameters).subscribe((resp: DataTableResponse) => {
          console.log("Result - ", resp);
          this.allApplications = resp.data
          callback({
            recordsTotal: resp.recordsTotal,
            recordsFiltered: resp.recordsFiltered,
            data: []
          });
        });
      },
      // columns: [{ data: 'applicationName'}]
    };
  }


}
