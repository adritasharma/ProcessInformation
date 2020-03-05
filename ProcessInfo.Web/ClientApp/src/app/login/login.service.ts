import { Injectable } from '@angular/core';
import { HttpService } from '../_common/core/services/http.service';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ILoginResponse, ILoginRequest } from '../_common/shared/models/login.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends HttpService {

  loginUrl = `${environment.apiUrl}user/login`;

  constructor(public _http: HttpClient) {
    super(_http);
  }

  login(loginData: ILoginRequest): Observable<ILoginResponse> {
    return this.post(this.loginUrl,loginData)

    // return of({
    //   userId:1,
    //   userName: "adrita",
    //   token: "gsfsfbjsfsj",
    //   firstName: "Adrita",
    //   lastName: "Sharma",
    //   userType: loginData.userName == 'admin' ? 1 : 0
    // })
  }


}
