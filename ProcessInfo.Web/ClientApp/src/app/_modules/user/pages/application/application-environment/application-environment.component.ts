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

  envData: any = {}

  ngOnInit() {
  }

  saveData(data: any) {
    data.applicationId = this.applicationId;
    this._applicationService.saveApplicationEnvironment(data).subscribe(resp => {
      console.log(resp)
    })
  }

}
