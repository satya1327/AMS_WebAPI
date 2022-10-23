import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { RequestComponent } from './request/request.component';
import { EditRequestComponent } from './edit-request/edit-request.component';
import { SharedModuleModule } from '../shared/shared-module.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { landingPageComponent } from './landing-page/landingPage.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatModulesModule } from 'src/app/shared/material/mat-modules.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserViewHistoryComponent } from './user-view-history/user-view-history.component';
import { AgGridModule } from 'ag-grid-angular';
@NgModule({
  declarations: [
    EditRequestComponent,
    RequestComponent,
    landingPageComponent,
    UserViewHistoryComponent,
  ],
  imports: [
    CommonModule,
    MatModulesModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    SharedModuleModule,
    Ng2SearchPipeModule,
    AgGridModule,
    FormsModule
  ],
  exports: [landingPageComponent, UserViewHistoryComponent],
})
export class UserModule {}
