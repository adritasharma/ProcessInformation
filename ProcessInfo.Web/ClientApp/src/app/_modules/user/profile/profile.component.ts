import { Component, OnInit } from '@angular/core';
import { ProfileService } from './profile.service';
import { SessionService } from 'src/app/_common/shared/services/session.service';
import { IUser } from 'src/app/_common/shared/models/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private _profileService: ProfileService, private _session:SessionService) { }

  userData:IUser

  ngOnInit() {
    this._profileService.getUserData(this._session.getLoggedinUserData().userId).subscribe( resp => {
      this.userData = resp
    })
  }

}
