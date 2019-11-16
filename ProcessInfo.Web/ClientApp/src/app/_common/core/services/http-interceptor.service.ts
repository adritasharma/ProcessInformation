import { Injectable } from '@angular/core';
import { LoaderService } from './loader.service';
import { HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService {

  constructor(private loaderService: LoaderService) { }

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
          // console.log(error);
          // if (error.error != undefined || error.error != null) {
          //   if (typeof error.error == "string") {
          //     let errorMessage: string = "Something Went Wrong!"

          //     errorMessage = error.error

          //     toastr.options = {
          //       "closeButton": true,
          //       "timeOut": 0,
          //     }
          //     toastr.error(errorMessage);
          //   } else if (typeof error.error == "object") {
          //     this.checkErrorService.callLoadData(error.error);
          //   }
          // }

        })
      )

    // } else {
    //   // this.sessionService.logOut()
    //   // toastr.warning("Session Timed Out! Please Login");
    //   // this.router.navigate(['/'])
    // }

  }

}
