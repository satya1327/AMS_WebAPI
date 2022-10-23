import { RequestStatusServiceService } from './../../../Core/RequestOperations/RequestStatusOperations/request-status-service.service';
import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { NotificationService } from './../../../Core/notification.service';
import { Route, Router } from '@angular/router';
import { RejectDialogComponent } from '../reject-dialog/reject-dialog.component';

import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-latest-request',
  templateUrl: './latest-request.component.html',
  styleUrls: ['./latest-request.component.css'],
})
export class LatestRequestComponent implements OnInit {
  latestRequest: any;
  statusId: any = 1;

  managerId: any = localStorage.getItem('adminId');
  constructor(
    private request: RequestServicesService,
    private matDialog: MatDialog,
    private route: Router,
    private toaster: NotificationService,
    private requeststatus: RequestStatusServiceService
  ) {}
  ngOnInit(): void {
    this.request.getRequests().subscribe((response: any) => {
      this.latestRequest = Object.values(
        response.filter(
          (item: any) =>
            (item.statusName == 'pending' &&
              item.managerId == this.managerId) ||
            item.statusName == 'forwarded'
        )
      )
        .reverse()
        .slice(0, 3);
    });
  }
  openRejectDialog() {
    this.matDialog.open(RejectDialogComponent, {
      width: '400px',
    });
  }
  approved(id: number) {
    this.request.GetRequestById(id).subscribe((response) => {
      response.statusId = 2;

      this.request.UpdateRequestById(id, response).subscribe((res) => {
        console.log(res);
        this.statusId = 2;
        let currentUrl = this.route.url;
        this.route.routeReuseStrategy.shouldReuseRoute = () => false;
        this.route.onSameUrlNavigation = 'reload';
        this.route.navigate([currentUrl]);
      });
      this.toaster.showSuccess('Approved', 'congratulations');
    });
  }
  rejected(id: any) {
    this.request.GetRequestById(id).subscribe((response) => {
      this.openRejectDialog();
    });
    this.request.sharedata(id);
  }
  forward(id: any) {
    this.request.GetRequestById(id).subscribe((response) => {
      response.statusId = 2002;
      response.ManagerId = 2;

      this.request.UpdateRequestById(id, response).subscribe((res) => {
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
