import { RequestServicesService } from './../../../Core/RequestOperations/CrudOperations/request-services.service';
import { requestModel } from 'src/app/Models/Request.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { NotificationService } from '../../../Core/notification.service';

@Component({
  selector: 'app-create-request-form',
  templateUrl: './create-request-form.component.html',
  styleUrls: ['./create-request-form.component.css'],
})
export class CreateRequestFormComponent implements OnInit {
  firstName: any = localStorage.getItem('AdminfirstName');
  lastName: any = localStorage.getItem('AdminlastName');
  name: any = this.firstName + this.lastName;
  managerId = localStorage.getItem('adminmanagerId');
  adminuserId = localStorage.getItem('adminId');
  requestModel = new requestModel();
  approve: any = this.requestModel.approved;
  createForm: FormGroup;
  date = new Date();
  constructor(
    private fb: FormBuilder,
    private toaster: NotificationService,
    private router: Router,

    private matdialog: MatDialog,
    private requestServices: RequestServicesService
  ) {}

  ngOnInit(): void {
    this.createForm = this.fb.group({
      purpose: ['', [Validators.required]],
      description: ['', [Validators.required]],
      estimatedAmount: ['', [Validators.required, Validators.maxLength(5)]],
      advAmount: ['', [Validators.required]],
      date: ['', [Validators.required]],
      comments: [''],
      managerid: [this.managerId],
      userid: [this.adminuserId],
    });
  }

  onSubmit() {
    this.requestServices.addRequest(this.createForm.value).subscribe((data) => {
      console.log(data);
      this.toaster.showSuccess('Request sent successfully', 'Congratulations');
      this.matdialog.closeAll();
      this.createForm.reset();
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    });
  }
}
