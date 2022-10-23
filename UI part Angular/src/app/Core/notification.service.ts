import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private toastr: ToastrService) {}

  public showSuccess(message: any, title: any) {
    this.toastr.success(message, title);
  }

  public showError(message: any, title: any) {
    this.toastr.error(message, title);
  }
  public showInfo(message: any, title: any) {
    this.toastr.info(message, title);
  }
  public showWarning(message: any, title: any) {
    this.toastr.warning(message, title);
  }
}
