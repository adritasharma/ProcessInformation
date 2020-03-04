import { Component, OnInit, ViewChild } from '@angular/core';
import { ApplicationService } from '../application.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Application } from 'src/app/_common/shared/models/application.model';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';
@Component({
  selector: 'app-list-application',
  templateUrl: './list-application.component.html',
  styleUrls: ['./list-application.component.css']
})
export class ListApplicationComponent implements OnInit {


  constructor(private _notification: NotificationService, private _applicationService: ApplicationService, private router: Router) { }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;
  status: string = "Active"
  allApplications: Application[] = []

  componentHeaderData = {
    Title: "Applications",
    AddRouterLink: ['/user/application/save']
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

        that._applicationService.getAllApplications(dataTablesParameters).subscribe((resp: DataTableResponse) => {
          console.log("Result - ", resp);
          this.allApplications = resp.data
          callback({
            recordsTotal: resp.totalRecords,
            recordsFiltered: resp.totalRecordsFiltered,
            data: []
          });
        });
      },
      columns: [{ "orderable": false, "searchable": false }, { data: 'ApplicationName' }, { data: 'applicationType' }, { data: 'projectName' }, { data: 'teamMemberNames', "orderable": false, "searchable": false }]
    };
  }

  deleteApplication(id, name) {
    this._notification.confirm(`Delete ApplicationType ${name}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._applicationService.deleteApplication(id).subscribe(res => {
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
