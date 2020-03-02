import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';
import { IApplicationType } from 'src/app/_common/shared/models/application-type.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationTypeService extends HttpService {

  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }


applicationTypeUrl = `${environment.apiUrl}applicationType`;

saveApplicationType(payload: IApplicationType): Observable<any> {
  return this.post(`${this.applicationTypeUrl}`, payload)
}

getAllApplicationTypes(dataTablesParameters: any): Observable<any> {
  if (dataTablesParameters) {
    return this.get(`${this.applicationTypeUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  } else {
    return this.get(`${this.applicationTypeUrl}`)
  }
}

getApplicationTypeById(id: any): Observable<IApplicationType> {
  return this.get(`${this.applicationTypeUrl}/${id}`)
}

updateApplicationType(payload: any): Observable<any> {
  return this.update(`${this.applicationTypeUrl}`, payload)
}

deleteApplicationType(id: string): Observable<any> {
  return this.delete(`${this.applicationTypeUrl}/${id}`)
}

}
