import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { NotificationService } from '../../../Core/notification.service';

@Component({
  selector: 'app-edit-request',
  templateUrl: './edit-request.component.html',
  styleUrls: ['./edit-request.component.css'],
})
export class EditRequestComponent implements OnInit {
  id: any;
  editForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private toaster: NotificationService,
    private router: Router,

    private matdialog: MatDialog,
    private request: RequestServicesService
  ) {
    this.request.subject.subscribe((data) => {
      this.id = data;
    });
    this.editForm = this.fb.group({
      purpose: ['', [Validators.required]],
      description: ['', [Validators.required]],
      estimatedAmount: ['', [Validators.required]],

      advAmount: ['', [Validators.required]],
      date: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.request.GetRequestById(this.id).subscribe((response) => {
      console.log(response);
      this.editForm = this.fb.group({
        purpose: [response['purpose']],
        description: [response['description']],
        estimatedAmount: [response['estimatedAmount']],

        advAmount: [response['advAmount']],
        date: [response['date']],
      });
    });
  }
  onSubmit() {
    this.request
      .UpdateRequestById(this.id, this.editForm.value)
      .subscribe((data) => {
        this.matdialog.closeAll();
        this.editForm.reset();
        let currentUrl = this.router.url;
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate([currentUrl]);
      });
    this.toaster.showSuccess('Congratulations', 'updated successfully');
  }
}
