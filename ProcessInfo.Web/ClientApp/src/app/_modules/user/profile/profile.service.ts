import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { IUser } from 'src/app/_common/shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService extends HttpService{

constructor(public _http: HttpClient) {
  super(_http);
}

getUserData(userId: number): Observable<any> {
  // return this.post("http://www.mocky.io/v2/5d7dcdfc2f00000834fedf90",loginData)

  return of({
    userId:1,
    firstName: "Adrita",
    lastName: "Sharma",
    fullName: "Adrita Sharma"
  })
}
}
