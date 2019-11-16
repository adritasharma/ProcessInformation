import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { ITour } from 'src/app/_common/shared/models/tour.model';
import { HttpService } from 'src/app/_common/core/services/http.service';

@Component({
  selector: 'list-tours',
  templateUrl: './list-tours.component.html',
  styleUrls: ['./list-tours.component.css']
})
export class ListToursComponent implements OnInit {

  @Input() Tours: Observable<ITour[]>

  constructor() {
  }


  ngOnInit() {
  }

}
