import { Component, OnInit, Input } from '@angular/core';
import { GoogleChartModel } from '../../models/google-chart.model';
import { ChartErrorEvent, ChartEvent } from 'angular-google-charts';

@Component({
  selector: 'custom-chart',
  templateUrl: './custom-chart.component.html',
  styleUrls: ['./custom-chart.component.css']
})
export class CustomChartComponent implements OnInit {

  constructor() { }

  @Input() chart: GoogleChartModel

  ngOnInit() {
  }

  onReady() {
  //  console.log('Chart ready');
  }

  onError(error: ChartErrorEvent) {
    console.error('Error: ' + error.message.toString());
  }

  onSelect(event: ChartEvent) {
   // console.log('Selected: ' + event.toString());
  }

  onMouseEnter(event: ChartEvent) {
    //console.log('Hovering ' + event.toString());
  }

  onMouseLeave(event: ChartEvent) {
   // console.log('No longer hovering ' + event.toString());
  }

}
