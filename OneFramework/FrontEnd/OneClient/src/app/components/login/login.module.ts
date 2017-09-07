import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { LoginComponent } from './../index';
import { NoAuthGuard } from '../../auth/index';
import { SharedModule } from '../../shared/index';

const authRouting: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'login',
    component: LoginComponent,
    // canActivate: [NoAuthGuard],
  },
]);

@NgModule({
  imports: [
    authRouting,
    SharedModule,
  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    NoAuthGuard
  ]
})
export class LoginModule {}
