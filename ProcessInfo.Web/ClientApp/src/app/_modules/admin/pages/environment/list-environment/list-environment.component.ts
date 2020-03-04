import { Component, OnInit, ViewChild } from '@angular/core';
import { EnvironmentService } from '../environment.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';

@Component({
  selector: 'app-list-environment',
  templateUrl: './list-environment.component.html',
  styleUrls: ['./list-environment.component.css']
})
export class ListEnvironmentComponent implements OnInit {

  constructor(private _environmentService: EnvironmentService, private _notification: NotificationService,private router: Router) { }

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
            recordsTotal: resp.totalRecords,
            recordsFiltered: resp.totalRecordsFiltered,
            data: []
          });
        });
      },
      columns: [{ "orderable": false, "searchable": false }, { data: 'environmentName' }, { data: 'environmentDescription' }]
    };
  }


  deleteEnvironment(id,name) {
    this._notification.confirm(`Delete Environment ${name}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._environmentService.deleteEnvironment(id).subscribe(res => {
            this.reload();
          })
        }
      })
      .catch(() => {
      });
  }

  reload() {
    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.ajax.reload()
    });
  }
}
