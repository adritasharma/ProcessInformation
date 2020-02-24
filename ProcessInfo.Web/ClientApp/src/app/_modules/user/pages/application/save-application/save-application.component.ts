import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Application, IApplication } from 'src/app/_common/shared/models/application.model';
import { ApplicationService } from '../application.service';
import { Router } from '@angular/router';
import { ProjectType } from 'src/app/_common/shared/enums/enum';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';

@Component({
  selector: 'save-application',
  templateUrl: './save-application.component.html',
  styleUrls: ['./save-application.component.css']
})
export class SaveApplicationComponent implements OnInit {

  constructor(private _applicationService: ApplicationService, private _router: Router, private _utility:UtilityService) { }

  applicationData = new Application()


  @Input() editApplicationData: any
  @Output() OnSave = new EventEmitter();

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }

  projectTypes = this._utility.getArrayFromEnum(ProjectType);
  
  ngOnInit() {
    if (this.editApplicationData) {
      this.applicationData = this.editApplicationData;
    }
  }

  saveData() {

    let requestUrl = this.editApplicationData ? this._applicationService.updateApplication(this.applicationData) : this._applicationService.saveApplication(this.applicationData);

    requestUrl.subscribe(resp => {
      console.log(resp);

      if (this.editApplicationData) {
        this.OnSave.emit();
      } else {
        this._router.navigate(this.componentHeaderData.BackRouterLink);
      }

    })
  }



}
