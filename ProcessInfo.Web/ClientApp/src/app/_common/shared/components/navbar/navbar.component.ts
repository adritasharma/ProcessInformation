import { Component, OnInit } from '@angular/core';
import { SessionService } from '../../services/session.service';
import { CheckLoginService } from 'src/app/_common/core/services/check-login.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _session: SessionService, private _checkLogin: CheckLoginService, private _router:Router) { }

  userFirstName: string = null

  isLoggedIn$: Observable<boolean> = this._checkLogin.isLoggedIn;  

  ngOnInit() {

    this.isLoggedIn$.subscribe(val => {
      if (this._session.getLoggedinUserData()) {
        this.userFirstName = this._session.getLoggedinUserData().firstName
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
