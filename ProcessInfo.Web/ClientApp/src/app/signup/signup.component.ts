import { Component, OnInit } from '@angular/core';
import { UserService } from '../_common/shared/services/user.service';
import { User } from '../_common/shared/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private _router: Router, private _userService: UserService) { }

  userdetails = new User

  ngOnInit() {
  }

  onSubmit() {


    this._userService.saveUser(this.userdetails).subscribe(resp => {
      console.log(resp);

      this._router.navigate(['/login']);

    })
  }

}
