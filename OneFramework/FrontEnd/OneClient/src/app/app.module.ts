import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';

import { AppRoutingModule }    from './app-routing.module';

import { AppComponent } from './components/app.component';
import { HeroDetailComponent } from './components/hero-detail/hero-detail.component';
import { HeroSearchComponent } from './components/hero-search/hero-search.component';
import { HeroesListComponent } from './components/hero-list/hero-list.component';

import { LoginModule } from './components/index';
import { DashboardModule } from './components/index';

import { HeroService, UserService, AuthService, ApiService, JwtService, HeroSearchService }         from './shared/services/index';

import { AppConfigModule } from './config/index';
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
    AuthService,
    ApiService,
    JwtService,
    HeroSearchService,
  ],
})
export class AppModule { }
