import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/_common/shared/models/application.model';

@Component({
  selector: 'app-save-application',
  templateUrl: './save-application.component.html',
  styleUrls: ['./save-application.component.css']
})
export class SaveApplicationComponent implements OnInit {

  constructor() { }

  applicationData = new Application()

  ngOnInit() {
  }

}
