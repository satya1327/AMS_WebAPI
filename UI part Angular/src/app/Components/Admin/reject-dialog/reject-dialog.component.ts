import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { NotificationService } from './../../../Core/notification.service';

import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reject-dialog',
  templateUrl: './reject-dialog.component.html',
  styleUrls: ['./reject-dialog.component.css'],
})
export class RejectDialogComponent implements OnInit {
  RejectForm: FormGroup;

  id: any;

  constructor(
    private fb: FormBuilder,
    private mat: MatDialog,
    private request: RequestServicesService,
    private toaster: NotificationService,
    private route: Router
  ) {
    this.request.subject.subscribe((response) => {
      this.id = response;
      console.log('i m from reject' + this.id);
    });
  }

  ngOnInit(): void {
    this.RejectForm = this.fb.group({
      comments: ['', [Validators.required]],
    });
  }
  submitRejectRequest() {
    this.request.GetRequestById(this.id).subscribe((response) => {
      console.log(response);
      response.statusId = 3;
      response.comments = this.RejectForm.get('comments').value;
      this.request
        .UpdateRequestById(this.id, response)
        .subscribe((response) => {
          console.log('from response' + response);
          let currentUrl = this.route.url;
          this.route.routeReuseStrategy.shouldReuseRoute = () => false;
          this.route.onSameUrlNavigation = 'reload';
          this.route.navigate([currentUrl]);
        });
    });

    this.mat.closeAll();

    this.toaster.showSuccess('Rejected', 'congratulations');
  }
  onCancel() {
    this.mat.closeAll();
  }
}
