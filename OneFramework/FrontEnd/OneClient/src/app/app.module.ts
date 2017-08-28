import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';

import { AppRoutingModule }    from './app-routing.module';

import { AppComponent } from './components/app.component';
import { HeroDetailComponent } from './components/hero-detail.component';
import { HeroSearchComponent } from './components/hero-search.component';
import { HeroesListComponent } from './components/hero-list.component';

import { LoginModule } from './components/login/index';
import { DashboardModule } from './components/dashboard/index';

import { HeroService }         from './services/hero.service';
import { UserService }         from './services/user.service';

import { AppConfigModule } from './app-config';
import { AuthGuard, NoAuthGuard } from './auth/index';
import { SharedModule } from './shared/index';

@NgModule({
  imports: [
    BrowserModule,
    AppConfigModule,
    LoginModule,
    SharedModule,
    AppRoutingModule,
    DashboardModule,
  ],
  declarations: [
    AppComponent,
    HeroDetailComponent,
    HeroSearchComponent,
    HeroesListComponent,
  ],
  bootstrap: [ AppComponent ],
  providers: [
    HeroService,
    UserService,
    AuthGuard,
    NoAuthGuard,
  ],
})
export class AppModule { }
