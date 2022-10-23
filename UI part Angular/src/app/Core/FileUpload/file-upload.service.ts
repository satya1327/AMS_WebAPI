import { requestModel } from './../../Models/Request.model';
import { environment } from './../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment } from 'ag-grid-community';
const fileUploadUrl = environment.FileuploadUrl;
@Injectable({
  providedIn: 'root',
})
export class FileUploadService {
  constructor(private http: HttpClient) {}

  public uploadBill(data: any): Observable<requestModel> {
    console.log(data);
    return this.http.post<requestModel>(`${fileUploadUrl}`, data);
  }
}
