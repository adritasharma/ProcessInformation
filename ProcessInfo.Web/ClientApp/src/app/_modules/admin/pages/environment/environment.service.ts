import { Injectable } from '@angular/core';
import { IAppEnvironment } from 'src/app/_common/shared/models/appEnvironment.model';
import { HttpClient } from '@angular/common/http';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/_common/core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentService extends HttpService  {

  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }

  environmentUrl = `${environment.apiUrl}environment`;

  saveEnvironment(payload: IAppEnvironment): Observable<any> {
    return this.post(`${this.environmentUrl}`, payload)
  }

  getAllEnvironments(dataTablesParameters: any): Observable<any> {
    return this.get(`${this.environmentUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  }

  getEnvironmentById(id: any): Observable<IAppEnvironment> {
     return this.get(`${this.environmentUrl}/${id}`)
   }
 

}
