import { Component, OnInit } from '@angular/core';
import { Application, IApplication } from 'src/app/_common/shared/models/application.model';
import { ApplicationService } from '../application.service';

@Component({
  selector: 'app-save-application',
  templateUrl: './save-application.component.html',
  styleUrls: ['./save-application.component.css']
})
export class SaveApplicationComponent implements OnInit {

  constructor(private _applicationService: ApplicationService) { }

  applicationData = new Application()

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }

  ngOnInit() {
  }

  saveData(data:IApplication){
    this._applicationService.saveApplication(data).subscribe(resp => {
      console.log(resp)
    })
  }

}
