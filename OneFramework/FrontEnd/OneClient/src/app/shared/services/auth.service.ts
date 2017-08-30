import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { ApiService } from './api.service';
import { JwtService } from './index';
import { User, UserInfo } from '../models/index';
import { Result, LoginResult } from '../models/index';


@Injectable()
export class AuthService {
  private currentUserSubject = new BehaviorSubject<LoginResult>(new LoginResult());
  public currentUser = this.currentUserSubject.asObservable().distinctUntilChanged();

  public isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  //   public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  private loginUrl = '/v1/account/login';
  private registerUrl = '/v1/account/register';

  constructor (
    private apiService: ApiService,
    private http: Http,
    private jwtService: JwtService
  ) {}

  // Verify JWT in localstorage with server & load user's info.
  // This runs once on application startup.
  populate() {
    console.log('populate');
    // If JWT detected, attempt to get & store user's info
    if (this.jwtService.getToken()) {
      this.isAuthenticatedSubject.next(true);
      this.apiService.get('/v1/user')
      .subscribe(
        data => {
          console.log(data.data.token);
          if(!data.data.token){
            data.data.token = this.jwtService.getToken();
          }
          this.setAuth(data.data);
        },
        err => this.purgeAuth()
      );
    } else {
      // Remove any potential remnants of previous auth states
      this.purgeAuth();
    }
  }

  setAuth(user: LoginResult) {
    console.log('setAuth');
    // Save JWT sent from server in localstorage
    this.jwtService.saveToken(user.token);
    // Set current user data into observable
    this.currentUserSubject.next(user);
    // Set isAuthenticated to true
    this.isAuthenticatedSubject.next(true);
  }

  purgeAuth() {
    console.log('purgeAuth');
    // Remove JWT from localstorage
    this.jwtService.destroyToken();
    // Set current user to an empty object
    this.currentUserSubject.next(new LoginResult());
    // Set auth status to false
    this.isAuthenticatedSubject.next(false);
  }

  // attemptAuth(type: any, credentials: any): Observable<User> {
  //   const route = (type === 'login') ? '/login' : '';
  //   return this.apiService.post('/users' + route, {user: credentials})
  //   .map(
  //     data => {
  //       this.setAuth(data.user);
  //       return data;
  //     }
  //   );
  // }

  login(user: User): Observable<Result>{
    return this.apiService
        .post(`${this.loginUrl}`, user)
        .map(data => {
          this.setAuth(data.data);
          return data;
        });
  }

  getCurrentUser(): LoginResult {
    return this.currentUserSubject.value;
  }

  // Update the user on the server (email, pass, etc)
  update(user: User): Observable<UserInfo> {
    return this.apiService
    .put('/user', { user })
    .map(data => {
      // Update the currentUser observable
      this.currentUserSubject.next(data.user);
      return data.user;
    });
  }

}
