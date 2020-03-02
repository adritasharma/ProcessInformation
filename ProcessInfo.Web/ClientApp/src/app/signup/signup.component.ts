import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../_common/shared/services/user.service';
import { User } from '../_common/shared/models/user.model';
import { Router } from '@angular/router';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private _router: Router, private _userService: UserService) { }

  userdetails = new User;
  passwordNotMatch: boolean = false

  @ViewChild('confirmPassword') confirmPassword: NgModel;

  ngOnInit() {
  }

  onSubmit() {


    this._userService.saveUser(this.userdetails).subscribe(resp => {
      console.log(resp);

      this._router.navigate(['/login']);

    })
  }

  matchPassword() {
    if (this.userdetails.password != '' && this.userdetails.confirmPassword != '') {
      if (this.userdetails.password != this.userdetails.confirmPassword) {
        this.passwordNotMatch = true
        this.confirmPassword.control.setErrors({ 'invalid': true })
      } else {
        this.passwordNotMatch = false
        this.confirmPassword.control.setErrors(null)
      }
    }
  }

}
