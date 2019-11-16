import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { ITour } from 'src/app/_common/shared/models/tour.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TourService extends HttpService {


  constructor(public _http: HttpClient) {
    super(_http);
  }

  getUserTours(): Observable<ITour[]> {
    return this.get("http://www.mocky.io/v2/5d7dcdfc2f00000834fedf90")
  }

}
