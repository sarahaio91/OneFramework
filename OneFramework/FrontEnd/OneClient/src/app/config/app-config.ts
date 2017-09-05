import { NgModule, InjectionToken } from '@angular/core';

export let APP_CONFIG = new InjectionToken<AppConfig>('app.config');

export class AppConfig {
  apiUrl: string;
  loginUrl: string;
  registerUrl: string;
  getUserUrl: string;
}

const APP_DI_CONFIG: AppConfig = {
  apiUrl: 'http://webapi20170820011416.azurewebsites.net',
  loginUrl: '/v1/account/login',
  registerUrl: '/v1/account/register',
  getUserUrl: '/v1/user',
};

@NgModule({
  providers: [{
    provide: APP_CONFIG,
    useValue: APP_DI_CONFIG
  }]
})
export class AppConfigModule { }