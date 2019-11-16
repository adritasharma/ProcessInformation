import { Component } from '@angular/core';
import { LoaderService } from './_common/core/services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'Angular StartUp';
  showLoader: boolean = false

  constructor(private loaderService: LoaderService) {

    this.loaderService.status.subscribe((val: boolean) => {
      var that = this
      setTimeout(function () {
        that.showLoader = val;
      }, 0);

    });
  }

}
