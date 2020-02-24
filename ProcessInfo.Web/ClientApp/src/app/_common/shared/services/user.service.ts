import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { UtilityService } from './utility.service';
import { IUser, User } from '../models/user.model';
import { Observable } from 'rxjs';
import { HttpService } from '../../core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends HttpService {


  constructor(public _http: HttpClient, private utility: UtilityService) {
    super(_http);
  }

  userUrl = `${environment.apiUrl}user`;
  userEnvironmentUrl = `${environment.apiUrl}user`;

  saveUser(payload: IUser): Observable<any> {
    return this.post(`${this.userUrl}`, payload)
  }

  updateUser(payload: IUser): Observable<any> {
    return this.update(`${this.userUrl}`, payload)
  }

  getAllUsers(dataTablesParameters: any): Observable<any> {
    return this.get(`${this.userUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  }

  getUserById(id: any): Observable<User> {
    return this.get(`${this.userUrl}/${id}`)
  }

  saveUserEnvironment(payload: any): Observable<any> {
    return this.post(`${this.userEnvironmentUrl}`, payload)
  }

  updateUserEnvironment(payload: any): Observable<any> {
    return this.update(`${this.userEnvironmentUrl}`, payload)
  }

  deleteUser(id: string): Observable<any> {
    return this.delete(`${this.userUrl}/${id}`)
  }
  deleteUserEnvironment(id: string): Observable<any> {
    return this.delete(`${this.userEnvironmentUrl}/${id}`)
  }

  getAllPorts(dataTablesParameters: any): Observable<any> {
    return this.get(`${this.userEnvironmentUrl}?${this.utility.convertToParam(dataTablesParameters)}`)
  }


}
