import { Component, OnInit } from '@angular/core';
import { LoginRequest, ILoginResponse } from '../_common/shared/models/login.model';
import { Router } from '@angular/router';
import { SessionService } from '../_common/shared/services/session.service';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _router: Router, private _session: SessionService, private _loginService: LoginService) { }

  userdetails: LoginRequest = new LoginRequest


  ngOnInit() {
    this._session.logOut()
  }

  login() {

    this._loginService.login(this.userdetails).subscribe(resp => {
      let userResponse: ILoginResponse = resp
      this._session.login(userResponse)

      if (userResponse.userType == 1) {
        this._router.navigate(['admin'])
      } else {
        this._router.navigate(['user'])
      }
    })
  }

}
