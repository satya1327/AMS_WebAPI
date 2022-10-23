// import { environment } from '../../environments/environment';

// import { HttpClient, HttpErrorResponse } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable, throwError } from 'rxjs';
// import { employee } from '../Models/employee.model';


// const url = environment.authUrl;
// @Injectable({
//   providedIn: 'root',
// })
// export class UserCreationService {
//   constructor(private http: HttpClient) {}
//   private handleError(errorResponse: HttpErrorResponse) {
//     if (errorResponse.error instanceof ErrorEvent) {
//       console.log('Client Side Error', errorResponse.error);
//     } else {
//       console.log('Server Side Error', errorResponse.error);
//     }
//     return throwError('Their is a problem in ur code');
//   }

//   ngOnInit(): void {}
//   public addUser(data: any): Observable<employee[]> {
//     return this.http.post<employee[]>(url, data);
//   }
// }
