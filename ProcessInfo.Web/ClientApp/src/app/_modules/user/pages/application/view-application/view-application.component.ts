import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../application.service';
import { Application } from 'src/app/_common/shared/models/application.model';

@Component({
  selector: 'app-view-application',
  templateUrl: './view-application.component.html',
  styleUrls: ['./view-application.component.css']
})
export class ViewApplicationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _applicationService: ApplicationService) { }

  paramId: any = null

  applicationDetails: Application

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }

  ngOnInit() {
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this._applicationService.getApplicationById(this.paramId).subscribe(res => {
        this.applicationDetails = res
        console.log(res)
      })
    }
  }

}
