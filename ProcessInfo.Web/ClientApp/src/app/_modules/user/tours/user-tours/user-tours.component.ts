import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ITour } from 'src/app/_common/shared/models/tour.model';
import { TourService } from '../tour.service';

@Component({
  selector: 'app-user-tours',
  templateUrl: './user-tours.component.html',
  styleUrls: ['./user-tours.component.css']
})
export class UserToursComponent implements OnInit {

  constructor(public _tour: TourService) {
  }

  private tourList$: Observable<ITour[]>

  ngOnInit() {
    this.tourList$ = this._tour.getUserTours();
  }

}
