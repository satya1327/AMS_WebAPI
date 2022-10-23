import { Observable } from 'rxjs';
import { requestModel } from 'src/app/Models/Request.model';
import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
const url = environment.RequestStatusUrl;
@Injectable({
  providedIn: 'root',
})
export class FetchRequestService {
  constructor(private http: HttpClient) {}

  public getTotalRequest(): Observable<requestModel> {
    return this.http.get<requestModel>(url + 'TotalRequest');
  }
  public ApprovedRquestCount(): Observable<requestModel> {
    return this.http.get<requestModel>(url + 'ApprovedRquestCount');
  }
  public RejectedRquestCount(): Observable<requestModel> {
    return this.http.get<requestModel>(url + 'RejectedRquestCount');
  }
}
