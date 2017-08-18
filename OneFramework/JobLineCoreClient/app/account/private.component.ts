import {Component} from 'angular2/core';
import {AuthenticatedService, User} from './account.service'
 
@Component({
    selector: 'login-form',
    providers: [AuthenticatedService],
    template: `
            <div class="container" >
                <div class="content">
                    <span>Congratulations, you have successfully logged in!!</span>
                    <br />
                    <a (click)="logout()" href="#">Click Here to logout</a>
                </div>
            </div>
    	`
})
 
export class PrivateComponent {
 
    constructor(
        private _service:AuthenticatedService){}
 
    ngOnInit(){
        this._service.checkCredentials();
    }
 
    logout() {
        this._service.logout();
    }
}