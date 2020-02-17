import { Injectable } from '@angular/core';
import { LoaderService } from './loader.service';
import { HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { NotificationService } from '../../shared/services/notification.service';


@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService {

  constructor(private loaderService: LoaderService, private toastr: NotificationService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token = "test";
    // || !this.jwt.isTokenExpired()
    //  if (token == null) {
    this.loaderService.display(true);
    // this.checkErrorService.callLoadData('clear');

    const authRquest = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + token
      }
    })
    return next.handle(authRquest)
      .pipe(
        tap(event => {
          this.loaderService.display(false);

          if (event instanceof HttpResponse) {
          }
        }, error => {
          console.log(error);
          if (error.error != undefined || error.error != null) {
            this.displayErrorToastr(error.error)
          }

        })
      )

    // } else {
    //   // this.sessionService.logOut()
    //   // toastr.warning("Session Timed Out! Please Login");
    //   // this.router.navigate(['/'])
    // }

  }

  displayErrorToastr(errorData: any) {

    if (typeof errorData == "string") {
      let errorMessage: string = "Something Went Wrong!"

      errorMessage = errorData
      this.toastr.displayToastr("error", errorMessage);
    } else if (typeof errorData == "object") {
      let errorMessageList = []
      var errorObject = errorData;
      for (var property in errorObject) {
        console.log(errorObject[property])
        if (typeof errorObject[property] == "string") {
          errorMessageList.push(errorObject[property])
          this.toastr.displayToastr("error", errorObject[property]);
        } else {
          for (var i = 0; i < errorObject[property].length; i++) {
            errorMessageList.push(errorObject[property][i])
            this.toastr.displayToastr("error", errorObject[property][i]);
          }
        }
      }
    }
  }

}
