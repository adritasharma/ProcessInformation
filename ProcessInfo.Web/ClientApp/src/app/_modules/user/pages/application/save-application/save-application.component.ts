import { Component, OnInit, Input } from '@angular/core';
import { Application, IApplication } from 'src/app/_common/shared/models/application.model';
import { ApplicationService } from '../application.service';

@Component({
  selector: 'save-application',
  templateUrl: './save-application.component.html',
  styleUrls: ['./save-application.component.css']
})
export class SaveApplicationComponent implements OnInit {

  constructor(private _applicationService: ApplicationService) { }

  applicationData = new Application()

  @Input() editApplicationData: any

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }

  ngOnInit() {
    if(this.editApplicationData){
      this.applicationData = this.editApplicationData
    }
  }

  saveData(data:IApplication){
    this._applicationService.saveApplication(data).subscribe(resp => {
      console.log(resp)
    })
  }

}
