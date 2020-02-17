import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationDialogComponent } from '../components/confirmation-dialog/confirmation-dialog.component';
declare var toastr;

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private modalService: NgbModal) { }

  public confirm(
    message: string,
    title: string = "Are You Sure to",
    btnOkText: string = 'OK',
    btnCancelText: string = 'Cancel',
    dialogSize: 'sm'|'lg' = 'sm'): Promise<boolean> {
    const modalRef = this.modalService.open(ConfirmationDialogComponent, { size: dialogSize });
    modalRef.componentInstance.title = title;
    modalRef.componentInstance.message = message;
    modalRef.componentInstance.btnOkText = btnOkText;
    modalRef.componentInstance.btnCancelText = btnCancelText;

    return modalRef.result;
  }


  displayToastr(type?: string, message?: string, isMultiple?: boolean, autoFade?: boolean) {

    var timeOut: any = "5000"

    if (autoFade == false) {
      timeOut = "0"
    }
    toastr.options = {
      "closeButton": true,
      "timeOut": timeOut,
      "positionClass": "toast-top-full-width",
      // "timeOut": "5000000000",
      // "extendedTimeOut": "5000000000",
    }

    switch (type) {

      case "success":

        if (message == null) {
          message = "Data Saved Successfully";
        }
        toastr.success(message);

        break;

      case "error":
        if (message == null) {
          message = "Something Went Wrong!";
        }
        toastr.error(message);

        break;

      case "warning":

        if (message == null) {
          message = "Warning!";
        }
        toastr.warning(message);

        break;

      case "clear":

        toastr.clear();

        break;

    }
  }

}
