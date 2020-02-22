import { Component, OnInit } from '@angular/core';
import { GoogleChartModel } from 'src/app/_common/shared/models/google-chart.model';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  projectType: GoogleChartModel = {
    title: 'Project Type',
    type: 'PieChart',
    data: [
      ["Demo", 5, 'red'],
      ["Temporary", 15, '#b87333'],
      ["Real Time", 5, 'yellow'],
    ],
    options: {
      pieHole: 0.4,
      colors: ['#2c9e1e', '#c7c7c7','yellow']
    },
  }

  applicationType: GoogleChartModel = {
    title: 'Application Type',
    type: 'ColumnChart',
    columnNames: ['Type', 'Count'],
    roles: [
      { role: 'style', type: 'string' }
    ],
    data: [
      ["UI", 5, 'red'],
      ["API", 15, '#b87333'],
      ["Backend Service", 5, 'yellow'],
      ["Package", 15, 'indigo'],
      ["VBA", 15, 'salmon']
    ],
    options: {
      legend: { position: 'none' },
      vAxis: {
        viewWindow: {
          min: 0,
        },
      }
    }
  }


}
