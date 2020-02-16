import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../application.service';
import { Application } from 'src/app/_common/shared/models/application.model';
import { ModalService } from 'src/app/_common/shared/services/modal.service';
import { EnvironmentService } from 'src/app/_modules/admin/pages/environment/environment.service';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';

@Component({
  selector: 'app-view-application',
  templateUrl: './view-application.component.html',
  styleUrls: ['./view-application.component.css']
})
export class ViewApplicationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _applicationService: ApplicationService,private _environmentService: EnvironmentService, public modalService: ModalService) { }

  paramId: any = null

  applicationDetails: Application = new Application
  editApplicationData: Application

  allEnvironments: AppEnvironment[] = [];


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

  getApplicationDetails(){
    this._applicationService.getApplicationById(this.paramId).subscribe(res => {
      this.applicationDetails = res
      console.log(res)
    })
  }

  editApplication() {
    this.editApplicationData = { ...this.applicationDetails }
  }

  getEnvironments(){
    this._environmentService.getAllEnvironments(null).subscribe(resp => {
      resp = resp.map(item => ({
        id:item.environmentId,
        text:item.environmentName,
      }))
      this.allEnvironments = resp
    })
  }

}
