import { environment } from './../../../../environments/environment';
import { requestModel } from 'src/app/Models/Request.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
const requestUrl = environment.RequestUrl;
@Injectable({
  providedIn: 'root',
})
export class RequestServicesService {
  public subject = new Subject();
  private _refresh = new Subject<void>();

  get refreshRequired() {
    return this._refresh;
  }

  constructor(private http: HttpClient) {}
  public addRequest(data: any): Observable<requestModel> {
    data.status_id = 1;
    return this.http.post<requestModel>(`${requestUrl}addRequest`, data).pipe(
      tap(() => {
        this.refreshRequired.next();
      })
    );
  }

  public getRequests(): Observable<requestModel[]> {
    return this.http.get<requestModel[]>(`${requestUrl}GetAllRequest`).pipe(
      tap(() => {
        this.refreshRequired.next();
      })
    );
  }

  public GetAllRequestHistory(): Observable<requestModel[]> {
    return this.http
      .get<requestModel[]>(`${requestUrl}GetAllRequestHistory`)
      .pipe(
        tap(() => {
          this.refreshRequired.next();
        })
      );
  }
  public GetRequestById(userid: any): Observable<requestModel> {
    return this.http
      .get<requestModel>(`${requestUrl}GetRequestById/${userid}`)
      .pipe(
        tap(() => {
          this.refreshRequired.next();
        })
      );
  }
  public GetRequestUserById(userId: any): Observable<requestModel[]> {
    console.log('from Services' + userId);
    return this.http.get<requestModel[]>(
      `${requestUrl}GetRequestById/${userId}`
    );
  }
  public GetRequestByManagerId(userId: any): Observable<requestModel[]> {
    console.log('from Services' + userId);
    return this.http.get<requestModel[]>(
      `${requestUrl}GetRequestByManagerId/${userId}`
    );
  }

  public DeleteRequestById(id: any): Observable<requestModel> {
    console.log('from service' + id);
    return this.http.delete<requestModel>(`${requestUrl}${id}`).pipe(
      tap(() => {
        this.refreshRequired.next();
      })
    );
  }
  public UpdateRequestById(id: any, data: any): Observable<requestModel> {
    console.log('from service call' + id);
    return this.http
      .patch<requestModel>(`${requestUrl}UpadteRequest/${id}`, data)
      .pipe(
        tap(() => {
          this.refreshRequired.next();
        })
      );
  }

  public sharedata(data: any) {
    console.log('from service' + data);
    return this.subject.next(data);
  }
}
