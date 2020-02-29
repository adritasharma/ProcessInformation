import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_common/shared/services/user.service';
import { User } from 'src/app/_common/shared/models/user.model';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';

@Component({
  selector: 'app-save-user',
  templateUrl: './save-user.component.html',
  styleUrls: ['./save-user.component.css']
})
export class SaveUserComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _notification: NotificationService, private _router: Router, private _userService: UserService) { }

  userdetails = new User
  paramId: any = null

  isEdit: boolean = false;

  componentHeaderData = {
    Title: "Users",
    BackRouterLink: ['/admin/user']
  }

  ngOnInit() {
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this.isEdit = true;
      this.getUserDetails();
    }
  }
  getUserDetails() {
    this._userService.getUserById(this.paramId).subscribe(res => {
      this.userdetails = res
      console.log(res)
    })
  }

  onSubmit() {


    let requestUrl = this.isEdit ? this._userService.updateUser(this.userdetails) : this._userService.saveUser(this.userdetails);

    requestUrl.subscribe(resp => {
      console.log(resp);

      if (this.isEdit) {
        this.getUserDetails();
        this._notification.displayToastr("success", "User Updated Successfully")
      } else {
        this._router.navigate(this.componentHeaderData.BackRouterLink);
      }

    })
  }


}
