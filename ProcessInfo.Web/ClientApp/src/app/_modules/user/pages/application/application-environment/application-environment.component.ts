import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApplicationService } from '../application.service';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';

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

  getPort(value:string){
    if(!this.envData.applicationEnvironmentId){
      let index = value.indexOf(':')
      if(index != -1){
        this.envData.port = value.slice(index + 1, index + 5)
      }
    }
  }

}
