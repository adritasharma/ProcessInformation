import { Component, OnInit, ViewChild } from '@angular/core';
import { EnvironmentService } from '../environment.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';

@Component({
  selector: 'app-list-environment',
  templateUrl: './list-environment.component.html',
  styleUrls: ['./list-environment.component.css']
})
export class ListEnvironmentComponent implements OnInit {

  constructor(private _environmentService: EnvironmentService, private router: Router) { }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;
  allEnvironments: AppEnvironment[] = [];

  componentHeaderData = {
    Title: "Environments",
    AddRouterLink: ['/admin/environment/save']
  }
  ngOnInit() {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: false,
      ajax: (dataTablesParameters: any, callback) => {
       // dataTablesParameters.FilterType = this.status;

        that._environmentService.getAllEnvironments(dataTablesParameters).subscribe((resp: DataTableResponse) => {
          console.log("Result - ", resp);
          this.allEnvironments = resp.data
          callback({
            recordsTotal: resp.recordsTotal,
            recordsFiltered: resp.recordsFiltered,
            data: []
          });
        });
      },
      // columns: [{ data: 'environmentName'}]
    };
  }

}
