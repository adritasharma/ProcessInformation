import { Component, OnInit } from '@angular/core';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { EnvironmentService } from '../environment.service';

@Component({
  selector: 'app-save-environment',
  templateUrl: './save-environment.component.html',
  styleUrls: ['./save-environment.component.css']
})
export class SaveEnvironmentComponent implements OnInit {

  constructor(private _environmentService: EnvironmentService) { }

  environmentData:AppEnvironment = new AppEnvironment


  componentHeaderData = {
    Title: "Environment",
    BackRouterLink: ['/admin/environment']
  }

  ngOnInit() {
  
  }

  saveData(){
    this._environmentService.saveEnvironment(this.environmentData).subscribe(resp => {
      console.log(resp)
    })
  }


}
