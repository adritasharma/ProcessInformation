import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';
import { DataTableDirective } from 'angular-datatables';
import { DataTableResponse } from 'src/app/_common/shared/models/DataTableResponse.model';
import { UserService } from 'src/app/_common/shared/services/user.service';
import { User } from 'src/app/_common/shared/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  constructor(private _userService: UserService, private _notification: NotificationService, private router: Router) { }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;
  allUsers: User[] = [];

  componentHeaderData = {
    Title: "Users",
    AddRouterLink: ['/admin/user/save']
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

        that._userService.getAllUsers(dataTablesParameters).subscribe((resp: DataTableResponse) => {
          console.log("Result - ", resp);
          this.allUsers = resp.data
          callback({
            recordsTotal: resp.totalRecords,
            recordsFiltered: resp.totalRecordsFiltered,
            data: []
          });
        });
      },
      columns: [{ "orderable": false, "searchable": false }, { data: 'firstName' }, { data: 'emailAddress' }, { data: 'username' }, { "orderable": false, "searchable": false }]
    };
  }


  deleteUser(id, name) {
    this._notification.confirm(`Delete User ${name}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._userService.deleteUser(id).subscribe(res => {
            this.reload();
            this._notification.displayToastr("success", "User Deleted Successfully")

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
