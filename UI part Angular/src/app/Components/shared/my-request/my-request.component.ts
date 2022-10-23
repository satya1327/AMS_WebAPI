import { RequestServicesService } from './../../../Core/RequestOperations/CrudOperations/request-services.service';
import { UploadBillsComponent } from './../upload-bills/upload-bills.component';

import { Router } from '@angular/router';
import { EditRequestComponent } from '../../User/edit-request/edit-request.component';
import { NotificationService } from 'src/app/Core/notification.service';

import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { requestModel } from 'src/app/Models/Request.model';

@Component({
  selector: 'app-my-request',
  templateUrl: './my-request.component.html',
  styleUrls: ['./my-request.component.css'],
})
export class MyRequestComponent implements OnInit {
   firstName: any;


   lastName: any ;
   first_name: any=localStorage.getItem('firstName');
   adminId:any=localStorage.getItem('adminId');
   userId:any=localStorage.getItem('userId');
  myRequestList: any;
  constructor(

    private toaster: NotificationService,
    private matdialog: MatDialog,
    private router: Router,
    private requestData:RequestServicesService
  ) {}

  ngOnInit(): void {
    this.requestData.getRequests().subscribe((response) => {
      this.myRequestList = response.filter((item:any)=> item.userId== this.userId).reverse();

      console.log(this.myRequestList);
    });
    this.requestData.subject.subscribe((resposne) => {
      console.log(resposne);
    });

  }

  deleteCart(id: number) {
    this.requestData.DeleteRequestById(id).subscribe((response) => {
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
  openUploadDialog(id: any) {
    this.matdialog.open(UploadBillsComponent, {
      width: '750px',
    });
    console.log("from request"+id)
    this.requestData.sharedata(id);
  }


}
