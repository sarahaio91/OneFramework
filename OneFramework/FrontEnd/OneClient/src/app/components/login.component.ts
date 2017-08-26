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
        this.userService.login(new User() = {
            email: email,
            password: password
        })
            .subscribe(heroes => {
                this.heroes = heroes.slice(1, 5);
            });
    }
}
