import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { UtilityService } from 'src/app/_common/shared/services/utility.service';
import { IApplicationType } from 'src/app/_common/shared/models/application-type.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApplicationTypeService extends HttpService {

  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }


environmentUrl = `${environment.apiUrl}environment`;

saveApplicationType(payload: IApplicationType): Observable<any> {
  return this.post(`${this.environmentUrl}`, payload)
}

getAllApplicationTypes(dataTablesParameters: any): Observable<any> {
  if (dataTablesParameters) {
    return this.get(`${this.environmentUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  } else {
    return this.get(`${this.environmentUrl}`)
  }
}

getApplicationTypeById(id: any): Observable<IApplicationType> {
  return this.get(`${this.environmentUrl}/${id}`)
}

updateApplicationType(payload: any): Observable<any> {
  return this.update(`${this.environmentUrl}`, payload)
}

deleteApplicationType(id: string): Observable<any> {
  return this.delete(`${this.environmentUrl}/${id}`)
}

}
