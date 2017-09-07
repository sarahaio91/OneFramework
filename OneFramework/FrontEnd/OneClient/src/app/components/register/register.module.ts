import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegisterComponent } from './../index';
import { NoAuthGuard } from '../../auth/index';
import { SharedModule } from '../../shared/index';

const authRouting: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'register',
    component: RegisterComponent,
    // canActivate: [NoAuthGuard],
  },
]);

@NgModule({
  imports: [
    authRouting,
    SharedModule,
  ],
  declarations: [
    RegisterComponent
  ],
  providers: [
    NoAuthGuard
  ]
})
export class RegisterModule {}
