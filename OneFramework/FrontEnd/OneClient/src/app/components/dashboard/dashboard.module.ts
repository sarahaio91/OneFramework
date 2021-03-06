import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { DashboardComponent } from './../index';
import { NoAuthGuard, AuthGuard } from '../../auth/index';
import { SharedModule } from '../../shared/index';

const authRouting: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
]);

@NgModule({
  imports: [
    authRouting,
    SharedModule,
  ],
  declarations: [
    DashboardComponent
  ],

  providers: [
    NoAuthGuard
  ]
})
export class DashboardModule {}
