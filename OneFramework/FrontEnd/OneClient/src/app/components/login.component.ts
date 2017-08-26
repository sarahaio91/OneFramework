import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../models/user';
import { UserService } from '../services/user.service';


@Component({
    selector: 'my-login',
    styleUrls: ['../../scss/components/login.component.scss'],
    templateUrl: '../../views/login.component.html',
})
export class LoginComponent{

    constructor(
        private router: Router,
        private userService: UserService,
    ) {
        console.log('LoginComponent');
    }

    login(email: string, password: string) {
        const user : User = {
            email: email,
            password: password
        }; 
        this.userService.login(user)
        .subscribe(result => {
            if(result.state == 1){
                console.log(result.message);
            }
            // this.result = result.slice(1, 5);
        });
    }
}
