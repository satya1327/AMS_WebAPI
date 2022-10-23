import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { FetchRequestService } from './../../../Core/RequestOperations/FetchOperations/fetch-request.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  latestRequest: any;
  totalRequest: any;
  approvedRequest: any;
  rejectRequest: any;
  forwardRequest: any;
  managerId: any = localStorage.getItem('adminId');

  constructor(
    private requestDetails: FetchRequestService,
    private requset: RequestServicesService
  ) {}

  ngOnInit(): void {
    this.requset.getRequests().subscribe((response: any) => {
      this.totalRequest = response.filter(
        (item: any) =>
          item.statusName == 'pending' && item.managerId == this.managerId
      ).length;
      console.log(this.totalRequest);
      this.approvedRequest = response.filter(
        (item: any) =>
          item.statusName == 'approve' && item.managerId == this.managerId
      ).length;
      console.log(this.approvedRequest);
      this.rejectRequest = response.filter(
        (item: any) =>
          item.statusName == 'reject' && item.managerId == this.managerId
      ).length;
      this.forwardRequest = response.filter(
        (item: any) =>
          item.statusName == 'forwarded'
      ).length;
      console.log('from forward' + this.forwardRequest);
    });
  }
}
