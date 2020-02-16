import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
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
  @Input() envData: any = {}

  @Output() OnSave = new EventEmitter();



  ngOnInit() {
    if (!this.envData.applicationEnvironmentId) {
      this.envData.environmentId = null
    }
  }

  
  saveData(){
    this.envData.applicationId = this.applicationId;

    let requestUrl = this.envData.applicationEnvironmentId ? this._applicationService.updateApplicationEnvironment(this.envData) :this._applicationService.saveApplicationEnvironment(this.envData);

    requestUrl.subscribe(resp => {
      this.OnSave.emit();
    })
  }

}
