import { Component, OnInit, Input } from '@angular/core';
import { ApplicationService } from '../application.service';

@Component({
  selector: 'application-environment',
  templateUrl: './application-environment.component.html',
  styleUrls: ['./application-environment.component.css']
})
export class ApplicationEnvironmentComponent implements OnInit {

  constructor(private _applicationService: ApplicationService) { }

  @Input() applicationId: any
  @Input() allEnvironments: any

  envData: any = {}

  ngOnInit() {
    this.envData.environmentId = null
  }

  saveData() {
    this.envData.applicationId = this.applicationId;
    this._applicationService.saveApplicationEnvironment(this.envData).subscribe(resp => {
      console.log(resp)
    })
  }

}
