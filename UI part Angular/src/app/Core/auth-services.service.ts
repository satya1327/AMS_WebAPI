import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from './notification.service';
import { Token } from '@angular/compiler';

const usersUrl = environment.authUrl;
@Injectable({
  providedIn: 'root',
})
export class AuthServicesService {
  user: any;
  isAuthenticated = false;
  isAdmin = false;
  isUser = false;
  response: any;
  token: any;
  data: any;
  constructor(
    private http: HttpClient,
    private toastr: NotificationService,
    private router: Router
  ) {}
  public authenticateUser(data: any) {
    return this.http.post(usersUrl, data).subscribe((response: any) => {
      // console.log(response);
      this.user = response;
      this.data = data;
      console.log(this.user);

      // this.authenticateUsers();
      if (
        response.userDetails.roleId === 2 ||
        response.userDetails.roleId === 3
      ) {
        this.isAdmin = true;
        this.isAuthenticated = true;
        this.toastr.showSuccess('logged in successfully', 'congratulations');
        this.router.navigate(['/AdminDashboard/dashboard']);
        localStorage.setItem('adminId', response.userDetails.userId);
        localStorage.setItem('AdminfirstName', response.userDetails.firstName);
        localStorage.setItem('AdminlastName', response.userDetails.lastName);
        localStorage.setItem('adminmanagerId', response.userDetails.managerId);

        localStorage.setItem(
          'adminName',
          response.userDetails.firstName + ' ' + response.userDetails.lastName
        );
      } else if (response.userDetails.roleId === 1) {
        this.isUser = true;
        this.isAuthenticated = true;
        this.toastr.showSuccess('logged in successfully', 'congratulations');
        this.router.navigate(['/UserlandingPage']);
        localStorage.setItem('userId', response.userDetails.userId);
        localStorage.setItem('email', response.userDetails.email);
        localStorage.setItem('firstName', response.userDetails.firstName);
        localStorage.setItem('lastName', response.userDetails.lastName);
        localStorage.setItem('userName', response.userDetails.userName);
        localStorage.setItem('managerId', response.userDetails.managerId);
      }

      if (this.isAuthenticated == false) {
        this.toastr.showError('invalid credential', 'failed');
      }
    });
  }
}
