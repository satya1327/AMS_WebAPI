import { Observable, Subject, tap } from 'rxjs';
import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { requestModel } from 'src/app/Models/Request.model';
const RequestStatus = environment.RequestStatusUrl;
@Injectable({
  providedIn: 'root',
})
export class RequestStatusServiceService {
  Subject = new Subject();
  private _refresh = new Subject<void>();

  get refreshRequired() {
    return this._refresh;
  }

  constructor(private http: HttpClient) {}

  public UpdateRequestById(id: any, data: any): Observable<requestModel> {
    console.log('from service' + id);
    return this.http
      .patch<requestModel>(`${RequestStatus}ActionRequest/${id}`, data)
      .pipe(
        tap(() => {
          this.refreshRequired.next();
        })
      );
  }
}
