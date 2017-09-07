import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import {LoginViewModel} from './../index';

import { AuthService } from '../../shared/services/index';
import { User } from '../../shared/models/index';
import { ApiResponseState } from '../../shared/responses/1-shared/index';

@Component({
    selector: 'my-login',
    styleUrls: ['login.component.scss'],
    templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit {
    model: LoginViewModel;
    submitted = false;
    
    returnUrl: string;
    loading = false;

    form: FormGroup;
    email: FormControl;
    password: FormControl;

    hasError = false;
    errorMessage = "";

    constructor(
        private route: ActivatedRoute,
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
        
        this.createFormControl();
        this.createForm();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    createFormControl(){
        this.email = new FormControl(this.model.email, [
            Validators.required,
        ]);
        this.password = new FormControl(this.model.password,[
            Validators.required
        ]);
    }

    createForm(){
        this.form = this.fb.group({
            'email': this.email,
            'password': this.password,
          });
    }

    onSubmit() {
        this.submitted = true;
    }

    login() {
        this.loading = true;
        const model: User ={
            email: this.model.email,
            password: this.model.password,
        };

        this.authService.login(model)
        .subscribe(result => {
            this.loading = false;
            if (result.state == ApiResponseState.Success) {
                this.router.navigate([this.returnUrl]);
            }
            else{
                this.hasError = true;
                this.errorMessage = result.message;
            }
        });
    }
}
