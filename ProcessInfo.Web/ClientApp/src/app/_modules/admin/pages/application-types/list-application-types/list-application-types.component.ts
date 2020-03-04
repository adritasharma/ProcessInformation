import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';
import { ApplicationTypeService } from '../application-type.service';
import { ApplicationType } from 'src/app/_common/shared/models/application-type.model';

@Component({
  selector: 'app-list-applicationType',
  templateUrl: './list-application-types.component.html',
  styleUrls: ['./list-application-types.component.css']
})
export class ListApplicationTypeComponent implements OnInit {

  constructor(private _applicationTypeService: ApplicationTypeService, private _notification: NotificationService,private router: Router) { }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;
  allApplicationTypes: ApplicationType[] = [];

  componentHeaderData = {
    Title: "ApplicationTypes",
    AddRouterLink: ['/admin/application-type/save']
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

        that._applicationTypeService.getAllApplicationTypes(dataTablesParameters).subscribe((resp: DataTableResponse) => {
          console.log("Result - ", resp);
          this.allApplicationTypes = resp.data
          callback({
            recordsTotal: resp.totalRecords,
            recordsFiltered: resp.totalRecordsFiltered,
            data: []
          });
        });
      },
      columns: [{ "orderable": false, "searchable": false }, { data: 'applicationTypeName' }, { data: 'applicationTypeDescription' }]
    };
  }


  deleteApplicationType(id,name) {
    this._notification.confirm(`Delete ApplicationType ${name}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._applicationTypeService.deleteApplicationType(id).subscribe(res => {
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
