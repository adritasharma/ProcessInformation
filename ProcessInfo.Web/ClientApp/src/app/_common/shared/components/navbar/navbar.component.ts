import { Component, OnInit } from '@angular/core';
import { SessionService } from '../../services/session.service';
import { CheckLoginService } from 'src/app/_common/core/services/check-login.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserType } from '../../enums/enum';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _session: SessionService, private _checkLogin: CheckLoginService, private _router: Router) { }

  userFirstName: string = null

  isLoggedIn$: Observable<boolean> = this._checkLogin.isLoggedIn;

  dashboardLink: any;

  ngOnInit() {

    this.isLoggedIn$.subscribe(val => {
      let loginData = this._session.getLoggedinUserData();
      if (loginData) {
        this.userFirstName = loginData.firstName;
        if (loginData.userType == UserType.Admin) {
          this.dashboardLink = ['/admin/dashboard']
        } else {
          this.dashboardLink = ['/user/dashboard']
        }
      } else {
        this.userFirstName = null
      }
    })

  }

  logOut(): void {
    this._session.logOut()
    this._router.navigate(['/login'])
  }

}
