import { employee } from './../../../Models/employee.model';
import { EmployeeServicesService } from './../../../Core/EmployeeServices/employee-services.service';
import { NotificationService } from '../../../Core/notification.service';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { CustomValidators } from '../../../shared/pipes/custom-validators';
import { pipe, catchError } from 'rxjs';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  rolesId: any = '';

  roles: Role[] = [
    { value: 1, viewValue: 'user' },
    { value: 2, viewValue: 'admin' },
  ];
  managerId: employee[] = [];
  constructor(
    private formBuilder: FormBuilder,

    private toaster: NotificationService,
    private empServices: EmployeeServicesService
  ) {}

  ngOnInit(): void {
    this.empServices.getAllusers().subscribe((response: any) => {
      this.managerId = response.map((value: any) => ({
        id: value.userId,
        firstName: value.firstName,
      }));
      this.managerId = Object.values(
        response.filter((item: any) => item.roleId == 2)
      );
    });
    this.signupForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      userName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      RoleId: [''],
      ManagerId: [''],
      password: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '^(?:(?:(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]))|(?:(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|]))|(?:(?=.*[0-9])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|]))|(?:(?=.*[0-9])(?=.*[a-z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|]))).{8,32}$'
          ),
        ],
      ],
      //     confirmPassword: ['', [Validators.required]],
      //   },
      //   { validators: CustomValidators.passwordsMatching }
      // );
    });
  }

  onSubmit() {
    if (this.signupForm.value.RoleId == 2) {
      this.signupForm.value.ManagerId = 2;
    }
    this.empServices.addUser(this.signupForm.value).subscribe((response) => {
      console.log(response);
      this.toaster.showSuccess('Congratulation', 'User successfully added');
    });
  }
}
interface Role {
  value: number;
  viewValue: string;
}

interface Manager {
  id: string;
  firstName: string;
}
