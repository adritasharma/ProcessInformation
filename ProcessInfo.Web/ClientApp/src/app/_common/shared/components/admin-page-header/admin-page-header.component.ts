import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { LoaderService } from 'src/app/_common/core/services/loader.service';

@Component({
  selector: 'admin-page-header',
  templateUrl: './admin-page-header.component.html',
  styleUrls: ['./admin-page-header.component.css']
})
export class AdminPageHeaderComponent implements OnInit {

  @Input() options: any
  @Output() AddButtonClicked = new EventEmitter();

  constructor(private loaderService: LoaderService) { }

  ngOnInit() {
  }

  stopLoader() {
    this.loaderService.display(false);
  }
 
}
