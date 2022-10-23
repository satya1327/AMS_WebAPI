import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatModulesModule } from 'src/app/shared/material/mat-modules.module';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginRoutingModule } from './login-routing.module';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    MatModulesModule,
    ReactiveFormsModule,
    LoginRoutingModule,
    ToastrModule.forRoot({
      positionClass: 'top-right',
      closeButton: true,
      progressBar: true,
    }),
    BrowserAnimationsModule,
  ],
  exports: [LoginComponent],
})
export class LoginModule {}
