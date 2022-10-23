import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FileUploadService } from './../../../Core/FileUpload/file-upload.service';
import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-upload-bills',
  templateUrl: './upload-bills.component.html',
  styleUrls: ['./upload-bills.component.css'],
})
export class UploadBillsComponent implements OnInit {
  userid: any;
  status: any;
  uploadForm: FormGroup;
  userDetails: any[] = [];
  SelectedFile: File = null;
  data: any;
  uplodBillData: any;
  constructor(
    private services: RequestServicesService,
    private fb: FormBuilder,
    private cd: ChangeDetectorRef,
    private fileservices: FileUploadService,
    private toaster: ToastrService,
    private router: Router
  ) {
    this.services.subject.subscribe((response) => {
      this.userid = response;
      console.log('from req' + response);
    });
    this.uploadForm = this.fb.group({
      ReqId: ['', [Validators.required]],
      Comments: ['', [Validators.required]],
      SpendAmount: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.services.GetRequestById(this.userid).subscribe((response: any) => {
      console.log(response);
      this.data = response.statusName;
      this.userDetails.push(response);
      console.log(this.userDetails);

      this.uploadForm = this.fb.group({
        ReqId: [response['reqId']],
        Comments: ['', [Validators.required]],
        SpendAmount: ['', [Validators.required]],
      });
    });
  }

  onFileChange(event: any) {
    this.SelectedFile = <File>event.target.files[0];
  }
  onSubmit() {
    const formData = new FormData();
    formData.append('file', this.SelectedFile, this.SelectedFile.name);
    formData.append('ReqId', this.uploadForm.value.ReqId);
    formData.append('Comments', this.uploadForm.value.Comments);
    formData.append('SpendAmount', this.uploadForm.value.SpendAmount);
    this.fileservices.uploadBill(formData).subscribe((response: any) => {
      this.uplodBillData = response;
      this.services.GetRequestById(this.userid).subscribe((response) => {
        response.statusId = 1002;

        this.services
          .UpdateRequestById(this.userid, response)
          .subscribe((res) => {
            console.log(res);
            let currentUrl = this.router.url;
            this.router.routeReuseStrategy.shouldReuseRoute = () => false;
            this.router.onSameUrlNavigation = 'reload';
            this.router.navigate([currentUrl]);
          });
      });

      this.toaster.success('File uploaded successfully', 'Congratulations');
    });
  }
}
