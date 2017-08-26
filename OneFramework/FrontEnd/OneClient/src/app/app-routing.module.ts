import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './components/dashboard.component';
import { HeroesListComponent }  from './components/hero-list.component';
import { HeroDetailComponent }  from './components/hero-detail.component';
import { LoginComponent }  from './components/login.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/login',
  },
  {
    component: DashboardComponent,
    path: 'dashboard',
  },
  {
    component: HeroDetailComponent,
    path: 'detail/:id',
  },
  {
    component: HeroesListComponent,
    path: 'heroes',
  },
  {
    component: LoginComponent,
    path: 'login',
  },
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ],
})
export class AppRoutingModule {}
