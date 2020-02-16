import { Component, OnInit } from '@angular/core';
import { AppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { EnvironmentService } from '../environment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-save-environment',
  templateUrl: './save-environment.component.html',
  styleUrls: ['./save-environment.component.css']
})
export class SaveEnvironmentComponent implements OnInit {

  constructor(private _environmentService: EnvironmentService, private router: Router) { }

  environmentData:AppEnvironment = new AppEnvironment


  componentHeaderData = {
    Title: "Environment",
    BackRouterLink: ['/admin/environment']
  }

  ngOnInit() {
  
  }

  saveData(){
    this._environmentService.saveEnvironment(this.environmentData).subscribe(resp => {
     this.router.navigate(this.componentHeaderData.BackRouterLink)
    })
  }


}
