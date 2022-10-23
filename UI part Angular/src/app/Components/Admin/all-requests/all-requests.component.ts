import { RequestStatusServiceService } from './../../../Core/RequestOperations/RequestStatusOperations/request-status-service.service';
import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { NotificationService } from './../../../Core/notification.service';
import { Route, Router } from '@angular/router';

import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { requestModel } from 'src/app/Models/Request.model';

import { RejectDialogComponent } from '../../Admin/reject-dialog/reject-dialog.component';

@Component({
  selector: 'app-all-requests',
  templateUrl: './all-requests.component.html',
  styleUrls: ['./all-requests.component.css'],
})
export class AllRequestsComponent implements OnInit {
  status: any = 'initiated';
  firstName: any = localStorage.getItem('AdminfirstName');
  lastName: any = localStorage.getItem('AdminlastName');
  name: any = this.firstName + this.lastName;
  managerId: any = localStorage.getItem('adminId');

  allRequest: any;
  requestModel: requestModel;

  constructor(
    private requset: RequestServicesService,
    private matDialog: MatDialog,
    private route: Router,
    private toaster: NotificationService,
    private requeststatus: RequestStatusServiceService
  ) {}
  ngOnInit(): void {
    this.requset.getRequests().subscribe((response: any) => {
      this.allRequest = response
        .filter(
          (item: any) =>
            (item.statusName == 'pending' &&
              item.managerId == this.managerId) ||
            item.statusName == 'forwarded'
        )
        .reverse();
    });
  }
  openRejectDialog() {
    this.matDialog.open(RejectDialogComponent, {
      width: '400px',
    });
  }
  approved(id: any) {
    this.requset.GetRequestById(id).subscribe((response) => {
      response.statusId = 2;

      this.requset.UpdateRequestById(id, response).subscribe((res) => {
        console.log(res);
        let currentUrl = this.route.url;
        this.route.routeReuseStrategy.shouldReuseRoute = () => false;
        this.route.onSameUrlNavigation = 'reload';
        this.route.navigate([currentUrl]);
      });
      this.toaster.showSuccess('Approved', 'congratulations');
    });
  }
  rejected(id: any) {
    this.requset.GetRequestById(id).subscribe((response) => {});

    this.requset.sharedata(id);
  }
  forward(id: any) {
    this.requset.GetRequestById(id).subscribe((response) => {
      response.statusId = 2002;
      response.ManagerId = 2;

      this.requset.UpdateRequestById(id, response).subscribe((res) => {
        console.log(res);
        let currentUrl = this.route.url;
        this.route.routeReuseStrategy.shouldReuseRoute = () => false;
        this.route.onSameUrlNavigation = 'reload';
        this.route.navigate([currentUrl]);
      });
      this.toaster.showSuccess('forwarded', 'congratulations');
    });
  }
}
