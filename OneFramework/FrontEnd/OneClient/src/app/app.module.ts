import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms'; // <-- NgModel lives here
import { HttpModule }          from '@angular/http';

import { AppRoutingModule }    from './app-routing.module';
import { AppComponent } from './components/app.component';
import { HeroDetailComponent } from './components/hero-detail.component';
import { DashboardComponent }  from './components/dashboard.component';
import { HeroService }         from './services/hero.service';
import { UserService }         from './services/user.service';
import { HeroSearchComponent } from './components/hero-search.component';
import { HeroesListComponent } from './components/hero-list.component';
import { LoginComponent } from './components/login.component';

import { AppConfigModule } from './app-config';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule,
    AppConfigModule,
  ],
  declarations: [
    AppComponent,
    HeroDetailComponent,
    DashboardComponent,
    HeroSearchComponent,
    HeroesListComponent,
    LoginComponent,
  ],
  bootstrap: [ AppComponent ],
    providers: [
      HeroService,
      UserService
  ],
})
export class AppModule { }
