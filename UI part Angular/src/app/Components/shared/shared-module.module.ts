import { UploadBillsComponent } from './upload-bills/upload-bills.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MyRequestComponent } from './my-request/my-request.component';
import { CreateRequestComponent } from './create-request/create-request.component';

import { HttpClientModule } from '@angular/common/http';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { LoginModule } from './login/login.module';
import { MatModulesModule } from '../../shared/material/mat-modules.module';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModuleRoutingModule } from './shared-module-routing.module';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [HomeComponent  , SignupComponent  , PageNotFoundComponent  ,CreateRequestComponent,MyRequestComponent,UploadBillsComponent],
  imports: [
    CommonModule,
    SharedModuleRoutingModule,
    MatModulesModule,
    MatModulesModule,
    LoginModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    FormsModule
  ],
  exports: [HomeComponent, SignupComponent, PageNotFoundComponent,CreateRequestComponent,MyRequestComponent],
})
export class SharedModuleModule {}
