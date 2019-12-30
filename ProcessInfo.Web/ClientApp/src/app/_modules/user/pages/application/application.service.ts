import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IApplication } from 'src/app/_common/shared/models/application.model';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/_common/core/services/http.service';


@Injectable({
  providedIn: 'root'
})
export class ApplicationService extends HttpService {


  constructor(public _http: HttpClient) {
    super(_http);
  }

  saveApplication(loginData: IApplication): Observable<any> {
     return this.post(`${environment.apiUrl}application`,loginData)
  }


}
