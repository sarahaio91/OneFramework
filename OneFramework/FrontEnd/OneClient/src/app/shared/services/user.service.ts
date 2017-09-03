import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { User } from '../models/user';

import { APP_CONFIG, AppConfig } from '../../config/index';

@Injectable()
export class UserService {
    // REST
    private usersUrl = '/users';  // URL to web api

    private headers = new Headers({'Content-Type': 'application/json'});
    private options = new RequestOptions({ headers: this.headers });

    public isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
    // public isAuthenticated = this.isAuthenticatedSubject.asObservable();

    constructor(
        private http: Http,
        @Inject(APP_CONFIG) private config: AppConfig
    ) { }

    // register(email: string, password: string): Observable<Result>{
    //     return this.http
    //         .post(`${this.config.apiUrl}${this.registerUrl}`, JSON.stringify({email: email, password: password}), this.options)
    //         .map(this.extractData)
    //         .catch(this.handleError);
    // }

    private extractData(res: Response) {
        return res.json();
    }

    private handleError (error: Response | any) {
        console.log('HANDLE ERROR');
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}
