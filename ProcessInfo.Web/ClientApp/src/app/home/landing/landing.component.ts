import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { ITour } from 'src/app/_common/shared/models/tour.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  constructor(private _http: HttpService) {
   }

  private tourList$: Observable<ITour[]>

  ngOnInit() {
    //this.tourList$ = this._http.get("http://www.mocky.io/v2/5d7dcdfc2f00000834fedf90");
  }

}
