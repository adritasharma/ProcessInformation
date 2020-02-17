import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationService } from '../application.service';
import { Application } from 'src/app/_common/shared/models/application.model';
import { ModalService } from 'src/app/_common/shared/services/modal.service';
import { EnvironmentService } from 'src/app/_modules/admin/pages/environment/environment.service';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';

@Component({
  selector: 'app-view-application',
  templateUrl: './view-application.component.html',
  styleUrls: ['./view-application.component.css']
})
export class ViewApplicationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _applicationService: ApplicationService, private _environmentService: EnvironmentService, public modalService: ModalService, private _notification: NotificationService, private _router: Router) { }

  paramId: any = null

  applicationDetails: Application = new Application
  editApplicationData: Application

  allEnvironments: AppEnvironment[] = [];
  editEnvData: any = {}

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }

  ngOnInit() {
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this.getApplicationDetails();
    }

    this.getEnvironments()

  }

  getApplicationDetails() {
    this._applicationService.getApplicationById(this.paramId).subscribe(res => {
      this.applicationDetails = res
      console.log(res)
    })
  }

  editApplication() {
    this.editApplicationData = { ...this.applicationDetails }
  }
  editApplicationEnvironment(data) {
    this.editEnvData = { ...data }
  }

  getEnvironments() {
    this._environmentService.getAllEnvironments(null).subscribe(resp => {
      resp = resp.map(item => ({
        id: item.environmentId,
        text: item.environmentName,
      }))
      this.allEnvironments = resp
    })
  }

  deleteApplication() {
    this._notification.confirm(`Delete Application ${this.applicationDetails.applicationName}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._applicationService.deleteApplication(this.applicationDetails.applicationId).subscribe(res => {
            this._router.navigate(this.componentHeaderData.BackRouterLink)
          })
        }
      })
      .catch(() => {
      });
  }

  deleteApplicationEnvironment(id, name) {
    this._notification.confirm(`Delete Environment ${name}?`)
      .then((confirmed) => {
        if (confirmed) {
          this._applicationService.deleteApplicationEnvironment(id).subscribe(res => {
            this.getApplicationDetails()
          })
        }
      })
      .catch(() => {
      });
  }

}
