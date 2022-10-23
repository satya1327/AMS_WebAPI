import { employee } from './../../Models/employee.model';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
const EmployeeUrl = environment.EmployeeUrl;
@Injectable({
  providedIn: 'root',
})
export class EmployeeServicesService {
  constructor(private http: HttpClient) {}
  public getAllusers(): Observable<employee> {
    return this.http.get<employee>(EmployeeUrl + 'GetAllUser');
  }
  public addUser(data: any): Observable<employee> {
    return this.http.post<employee>(EmployeeUrl + 'AddUser', data);
  }
}
