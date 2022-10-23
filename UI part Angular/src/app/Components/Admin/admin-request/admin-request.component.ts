import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';

import { NotificationService } from '../../../Core/notification.service';
import { UploadBillsComponent } from '../../shared/upload-bills/upload-bills.component';
import { EditRequestComponent } from '../../User/edit-request/edit-request.component';

@Component({
  selector: 'app-admin-request',
  templateUrl: './admin-request.component.html',
  styleUrls: ['./admin-request.component.css'],
})
export class AdminRequestComponent implements OnInit {
  firstName: any = localStorage.getItem('AdminfirstName');
  lastName: any = localStorage.getItem('AdminlastName');
  name: any = this.firstName;
  adminId: any = localStorage.getItem('adminId');
  userId: any = localStorage.getItem('userId');

  myRequestList: any;
  constructor(
    private toaster: NotificationService,
    private matdialog: MatDialog,
    private router: Router,
    private requestData: RequestServicesService
  ) {}

  ngOnInit(): void {
    this.requestData.getRequests().subscribe((response) => {
      console.log(response);

      this.myRequestList = response.filter(
        (item: any) => item.userId == this.adminId
      );
    });
    this.requestData.subject.subscribe((resposne) => {
      console.log(resposne);
    });
  }

  deleteCart(id: any) {
    this.requestData.DeleteRequestById(id).subscribe((response) => {
      console.log(id);
      let deleteItem = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([deleteItem]);
      this.toaster.showWarning('Congratulation', 'SuccessFully Deleted');
    });
  }
  openEditDialog(id: any) {
    this.matdialog.open(EditRequestComponent, {
      width: '450px',
    });

    this.requestData.sharedata(id);
  }
  openUploadDialog(id: number) {
    this.matdialog.open(UploadBillsComponent, {
      width: '800px',
    });
    this.requestData.sharedata(id);
  }
}
