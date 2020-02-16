import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IApplication, Application } from 'src/app/_common/shared/models/application.model';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';


@Injectable({
  providedIn: 'root'
})
export class ApplicationService extends HttpService {


  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }

  applicationUrl = `${environment.apiUrl}application`;
  applicationEnvironmentUrl = `${environment.apiUrl}applicationEnvironment`;

  saveApplication(payload: IApplication): Observable<any> {
    return this.post(`${this.applicationUrl}`, payload)
  }

  updateApplication(payload: IApplication): Observable<any> {
    return this.update(`${this.applicationUrl}`, payload)
  }

  getAllApplications(dataTablesParameters: any): Observable<any> {
    return this.get(`${this.applicationUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  }

  getApplicationById(id: any): Observable<Application> {
     return this.get(`${this.applicationUrl}/${id}`)
   }
 
   saveApplicationEnvironment(payload: any): Observable<any> {
    return this.post(`${this.applicationEnvironmentUrl}`, payload)
  }

  updateApplicationEnvironment(payload: any): Observable<any> {
    return this.update(`${this.applicationEnvironmentUrl}`, payload)
  }

}
