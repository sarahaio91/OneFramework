import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import {LoginViewModel} from './index';

import { UserService } from '../../services/index';
import { User } from '../../models/index';

@Component({
    selector: 'my-login',
    styleUrls: ['login.component.scss'],
    templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit {
    model: LoginViewModel;
    submitted = false;
    loginForm: FormGroup;

    constructor(
        private router: Router,
        private userService: UserService,
        private fb: FormBuilder,
    ) {
        console.log('LoginComponent');
    }

    ngOnInit(): void {
        console.log('Ahihi');
        const model: LoginViewModel = {
            email: '',
            password: '',
        };
        this.model = model;
        this.loginForm = this.fb.group({
            'email': new FormControl(this.model.email, [
                Validators.required,
            ]),
            'password': new FormControl(this.model.password,[
                Validators.required
            ]),
          });
    }

    onSubmit() { this.submitted = true; }

    login() {
        console.log(this.model.email);
        console.log(this.model.password);

        const model: User ={
            email: this.model.email,
            password: this.model.password,
        };

        this.userService.login(model)
        .subscribe(result => {
            if(result.state == 1) {
                console.log(result.message);
                let link = ['/dashboard'];
                this.router.navigate(link);
            }
        });
    }
}
