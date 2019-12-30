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


  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }

  saveApplication(payload: IApplication): Observable<any> {
    return this.post(`${environment.apiUrl}application`, payload)
  }

  getAllApplications(dataTablesParameters: any): Observable<any> {
    return this.get(`${environment.apiUrl}application?${this.utility.convertToParam(dataTablesParameters)}`)
  }

  getApplicationById(id: any): Observable<Application> {
     return this.get(`${environment.apiUrl}application/${id}`)
   }
 

}
