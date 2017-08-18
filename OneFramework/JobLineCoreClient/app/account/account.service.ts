import {Injectable} from 'angular2/core';
import{Router} from 'angular2/router';
import{IUserInfo} from './UserInfo';
import {Http, Response} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import { Headers, URLSearchParams } from 'angular2/http';

export class User{
    constructor(
    public email: string,
    public password: string){};
}

var users = [new User('oaile','123456'), new User('namro','123456')];

@Injectable()
export class AuthenticatedService{
    private _userUrl = 'http://localhost:56081/api/user';
    constructor(private _router: Router, private _http : Http){}
    private _userInfo : IUserInfo;

    logout(){
        localStorage.removeItem('user');
        this._router.navigate(['Login'])
    }

    login(user){
        // this._http.get(this._newsUrl+"/"+user)
        // .map((response : Response) => <IUserInfo> response.json())
        // .subscribe  (
        //     data => {this._userInfo = data},
        //     err => console.error(err),
        //     ()=> console.log('Done')
        // );

       let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' }); 
        var params = new URLSearchParams();
            params.set('Username', user.userName);
            params.set('Password', user.password);

        this._http.post(this._userUrl+"/login", params.toString(), 
        { headers: headers }).map((response : Response) => <IUserInfo> response.json())
        .subscribe(
            data => {this._userInfo = data},
            err => console.error(err),
            ()=> console.log('Done')
        );

        //var authenticatedUser = this._userInfo.Username === null;
        if(this._userInfo.Username === user.Username){
            localStorage.setItem('user', JSON.stringify(this._userInfo));
            //localStorage.setItem("user", authenticatedUser);
            this._router.navigate(['Home']);
            return true;
        }
    }

    checkCredentials(){
        if(localStorage.getItem('user') === null){
            this._router.navigate(["Login"]);
        }
    }

    private handleError(error:Response){
        console.error('Test: '+error);
        return Observable.throw(error.json().error || 'Server error');
        
    }
}