import { ViewHistoryComponent } from '../view-history/view-history.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AdminRequestComponent } from '../admin-request/admin-request.component';
import { AllRequestsComponent } from '../all-requests/all-requests.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { SharedModuleModule } from '../../shared/shared-module.module';
import { CreateRequestFormComponent } from '../create-request-form/create-request-form.component';
import { LatestRequestComponent } from '../latest-request/latest-request.component';
import { AppRoutingModule } from '../../../app-routing.module';
import { AdminDashboardComponent } from '../admin-dashboard/admin-dashboard.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatModulesModule } from 'src/app/shared/material/mat-modules.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RejectDialogComponent } from '../reject-dialog/reject-dialog.component';
import { AgGridModule } from 'ag-grid-angular';



@NgModule({
  declarations: [
 AdminDashboardComponent,
 AllRequestsComponent,
 LatestRequestComponent,
 CreateRequestFormComponent,
 RejectDialogComponent,
 DashboardComponent,
 AdminRequestComponent,
 ViewHistoryComponent

  ],
  imports: [
    CommonModule,
    MatModulesModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FormsModule,
    SharedModuleModule,
    Ng2SearchPipeModule,
    AgGridModule


  ],
  exports: [
    AdminDashboardComponent,
    LatestRequestComponent,
    CreateRequestFormComponent,
    RejectDialogComponent,
    DashboardComponent,
    AllRequestsComponent,
    AdminRequestComponent,
    ViewHistoryComponent,

  ],
})
export class AdminModule {}
