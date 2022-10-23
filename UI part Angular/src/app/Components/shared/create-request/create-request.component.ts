import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router, TitleStrategy } from '@angular/router';

import { NotificationService } from '../../../Core/notification.service';

@Component({
  selector: 'app-create-request',
  templateUrl: './create-request.component.html',
  styleUrls: ['./create-request.component.css'],
})
export class CreateRequestComponent implements OnInit {
  firstName: any = localStorage.getItem('firstName');
  lastName: any = localStorage.getItem('lastName');
  managerId = localStorage.getItem('managerId');
  userId = localStorage.getItem('userId');

  name: any = this.firstName + this.lastName;

  createForm: FormGroup;
  date = new Date();
  constructor(
    private fb: FormBuilder,
    private toaster: NotificationService,
    private router: Router,
    private services: RequestServicesService,
    private matdialog: MatDialog
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
      userid: [this.userId],
    });
  }

  onSubmit() {
    this.services.addRequest(this.createForm.value).subscribe((data) => {
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
