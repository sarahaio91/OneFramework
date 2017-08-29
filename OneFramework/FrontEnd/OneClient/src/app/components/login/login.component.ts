import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import {LoginViewModel} from './../index';

import { AuthService } from '../../shared/services/index';
import { User } from '../../shared/models/index';

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
        private authService: AuthService,
        private fb: FormBuilder,
    ) {
        console.log('LoginComponent');
    }

    ngOnInit(): void {
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
        const model: User ={
            email: this.model.email,
            password: this.model.password,
        };

        this.authService.login(model)
        .subscribe(result => {
            if(result.state == 1) {
                let link = ['/dashboard'];
                this.router.navigate(link);
            }
        });
    }
}
