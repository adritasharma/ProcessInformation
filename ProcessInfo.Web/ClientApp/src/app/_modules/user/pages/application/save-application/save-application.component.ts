import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Application, IApplication } from 'src/app/_common/shared/models/application.model';
import { ApplicationService } from '../application.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectType } from 'src/app/_common/shared/enums/enum';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';
import { ApplicationTypeService } from 'src/app/_modules/admin/pages/application-types/application-type.service';

@Component({
  selector: 'save-application',
  templateUrl: './save-application.component.html',
  styleUrls: ['./save-application.component.css']
})
export class SaveApplicationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private _applicationService: ApplicationService, private _router: Router, private _utility: UtilityService, private _appTypeService: ApplicationTypeService) { }

  applicationData = new Application()


  @Input() editApplicationData: any
  @Output() OnSave = new EventEmitter();

  componentHeaderData = {
    Title: "Applications",
    BackRouterLink: ['/user/application/list']
  }
  paramId: any = null

  projectTypes = this._utility.getArrayFromEnum(ProjectType);

  options = {
    AllowNewItem: false,
    IsAutoCompleteObservable: true,
    identifyBy: 'userId',
    displayBy: 'firstName',
    ModelType: 'object'
  }

  technologyChipOptions = {
    AllowNewItem: true,
    ModelType: 'string'
  }

  isEdit: boolean = false;
  allApplicationTypes: any = []

  ngOnInit() {
    this.getApplicationTypes();

    if (this.editApplicationData) {
      this.applicationData = this.editApplicationData;
      this.isEdit = true;
    }
    this.paramId = this.route.snapshot.params["id"];

    if (this.paramId) {
      this.isEdit = true;
      this.getApplicationDetails();
    }
  }
  getApplicationDetails() {
    this._applicationService.getApplicationById(this.paramId).subscribe(res => {
      this.applicationData = res
      console.log(res)
    })
  }

  getApplicationTypes() {
    this._appTypeService.getAllApplicationTypes(null).subscribe(resp => {
      resp = resp.map(item => ({
        id: item.applicationTypeId,
        text: item.applicationTypeName,
      }))
      this.allApplicationTypes = resp
    })
  }
  saveData() {

    console.log(this.applicationData)

    let requestUrl = this.isEdit ? this._applicationService.updateApplication(this.applicationData) : this._applicationService.saveApplication(this.applicationData);

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
