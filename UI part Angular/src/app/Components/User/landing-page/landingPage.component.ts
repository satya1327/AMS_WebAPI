import { NotificationService } from '../../../Core/notification.service';

import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { requestModel } from '../../../Models/Request.model';
import { RequestComponent } from '../request/request.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-landingPage',
  templateUrl: './landingPage.component.html',
  styleUrls: ['./landingPage.component.css'],
})
export class landingPageComponent implements OnInit {
  firstName: any = localStorage.getItem('firstName');
  lastName: any = localStorage.getItem('lastName');

  ApprovalFormDetails: FormGroup;
  userModel: requestModel;
  currentDate: any = new Date();

  constructor(
    private formbuilder: FormBuilder,

    private toast: NotificationService,
    private matdialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.ApprovalFormDetails = this.formbuilder.group({
      purpose: ['', [Validators.required]],
      description: ['', [Validators.required]],
      approver: ['Jurgen'],
      estimateCost: ['', [Validators.required]],
      advanceAmount: ['', [Validators.required, Validators.maxLength(5)]],
      date: ['', [Validators.required]],
    });
    this.ApprovalFormDetails.controls['approver'].setValue('Jurgen');
  }
  openCreateDialog() {
    this.matdialog.open(RequestComponent, {
      width: '500px',
    });
  }
}
