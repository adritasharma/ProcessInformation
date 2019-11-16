import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SessionService } from '../services/session.service';
import { UserType } from '../enums/enum';

@Injectable({
    providedIn: 'root'
})
export class UserRouteGuard implements CanActivate {

    constructor(private router: Router, private _session: SessionService) { }

    canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        if (this._session.getLoggedinUserData() && this._session.getLoggedinUserData().userType == UserType.User) {
            return true;
        } else {
            this.router.navigate(['/login'])
            return false;
        }
    }

}
