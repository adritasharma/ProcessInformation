import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationTypeService } from '../application-type.service';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';

@Component({
  selector: 'app-save-application-type',
  templateUrl: './save-application-type.component.html',
  styleUrls: ['./save-application-type.component.css']
})
export class SaveApplicationTypeComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _applicationTypeService: ApplicationTypeService, private _notification: NotificationService, private _router: Router) { }

  paramId: any = null

  applicationTypeData: any = {}


  componentHeaderData = {
    Title: "Application Type",
    BackRouterLink: ['/admin/application-type']
  }

  ngOnInit() {
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this.getApplicationTypeDetails();
    }
  }

  getApplicationTypeDetails() {
    this._applicationTypeService.getApplicationTypeById(this.paramId).subscribe(res => {
      this.applicationTypeData = res
      console.log(res)
    })
  }



  saveData() {

    let requestUrl = this.paramId ? this._applicationTypeService.updateApplicationType(this.applicationTypeData) : this._applicationTypeService.saveApplicationType(this.applicationTypeData);

    requestUrl.subscribe(resp => {
      console.log(resp);
      this._router.navigate(this.componentHeaderData.BackRouterLink)
    })
  }


}
