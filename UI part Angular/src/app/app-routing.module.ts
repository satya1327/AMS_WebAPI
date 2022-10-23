import { UserViewHistoryComponent } from './Components/User/user-view-history/user-view-history.component';
import { ViewHistoryComponent } from './Components/Admin/view-history/view-history.component';
import { AuthguardGuard } from './Core/auth-guard.guard';
import { AdminRequestComponent } from '../app/Components/Admin/admin-request/admin-request.component';
import { AllRequestsComponent } from '../app/Components/Admin/all-requests/all-requests.component';
import { DashboardComponent } from '../app/Components/Admin/dashboard/dashboard.component';
import { LatestRequestComponent } from '../app/Components/Admin/latest-request/latest-request.component';
import { PageNotFoundComponent } from './Components/shared/page-not-found/page-not-found.component';
import { MyRequestComponent } from './Components/shared/my-request/my-request.component';
import { SignupComponent } from './Components/shared/signup/signup.component';
import { HomeComponent } from './Components/shared/home/home.component';
import { AdminDashboardComponent } from '../app/Components/Admin/admin-dashboard/admin-dashboard.component';
import { landingPageComponent} from './Components/User/landing-page/landingPage.component';
import { LoginComponent } from './Components/shared/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  {
    path: 'UserlandingPage',
    component: landingPageComponent,

    children: [{ path: 'myRequest', component: MyRequestComponent },{path:'userHistory',component:UserViewHistoryComponent}],
    canActivate:[AuthguardGuard]

  },
  {
    path: 'AdminDashboard',
    component: AdminDashboardComponent,
    canActivate:[AuthguardGuard],
    children: [
      { path: 'myRequest', component: MyRequestComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'latestRequest', component: LatestRequestComponent },
      { path: 'allRequest', component: AllRequestsComponent },
      {path:'myRequestComp',component:AdminRequestComponent},
      {path:'viewHistory',component:ViewHistoryComponent}
    ],
  },

  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
