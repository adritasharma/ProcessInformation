import { Injectable } from '@angular/core';
import { HttpService } from '../_common/core/services/http.service';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ILoginResponse, ILoginRequest } from '../_common/shared/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends HttpService {


  constructor(public _http: HttpClient) {
    super(_http);
  }

  login(loginData: ILoginRequest): Observable<ILoginResponse> {
    // return this.post("http://www.mocky.io/v2/5d7dcdfc2f00000834fedf90",loginData)

    return of({
      userId:1,
      userName: "adrita",
      token: "gsfsfbjsfsj",
      firstName: "Adrita",
      lastName: "Sharma",
      userType: 1
    })
  }


}
