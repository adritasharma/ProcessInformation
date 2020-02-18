import { Component, OnInit } from '@angular/core';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { EnvironmentService } from '../environment.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NotificationService } from 'src/app/_common/shared/services/notification.service';

@Component({
  selector: 'app-save-environment',
  templateUrl: './save-environment.component.html',
  styleUrls: ['./save-environment.component.css']
})
export class SaveEnvironmentComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _environmentService: EnvironmentService, private _notification: NotificationService, private _router: Router) { }

  paramId: any = null

  environmentData: any = {}


  componentHeaderData = {
    Title: "Environment",
    BackRouterLink: ['/admin/environment']
  }

  ngOnInit() {
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this.getEnvironmentDetails();
    }
  }

  getEnvironmentDetails() {
    this._environmentService.getEnvironmentById(this.paramId).subscribe(res => {
      this.environmentData = res
      console.log(res)
    })
  }



  saveData() {

    let requestUrl = this.paramId ? this._environmentService.updateEnvironment(this.environmentData) : this._environmentService.saveEnvironment(this.environmentData);

    requestUrl.subscribe(resp => {
      console.log(resp);
      this._router.navigate(this.componentHeaderData.BackRouterLink)
    })
  }



}
