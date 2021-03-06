import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import { RegisterViewModel } from './../index';

import { AuthService } from '../../shared/services/index';
import { Register } from '../../shared/models/index';
import { ApiResponseState } from '../../shared/responses/1-shared/index';

@Component({
    selector: 'my-register',
    // styleUrls: ['register.component.scss'],
    templateUrl: 'register.component.html',
})
export class RegisterComponent implements OnInit {
    model: RegisterViewModel;
    submitted = false;

    displayName: FormControl;
    email: FormControl;
    phoneNumber: FormControl;
    password: FormControl;
    confirmPassword: FormControl;

    form: FormGroup;
    passwords: FormGroup;

    returnUrl: string;
    loading = false;

    hasError = false;
    errorMessage = "";

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthService,
        private fb: FormBuilder,
    ) {
        console.log('RegisterComponent');
    }

    ngOnInit(): void {
        const model: RegisterViewModel = {
            displayName: '',
            email: '',
            password: '',
            confirmPassword: '',
            phoneNumber: '',
        };
        this.model = model;

        this.createFormControl();
        this.createForm();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    createFormControl() {
        this.displayName = new FormControl(this.model.displayName, [
            Validators.required,
        ]);
        this.email = new FormControl(this.model.email, [
            Validators.required,
            Validators.pattern('^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$'),
        ]);
        this.phoneNumber = new FormControl(this.model.phoneNumber, [

        ]);
        this.password = new FormControl(this.model.password, [
            Validators.required,
            Validators.minLength(5)
        ]);
        this.confirmPassword = new FormControl(this.model.confirmPassword, [
            Validators.required,
        ]);
    }

    createForm() {
        this.passwords = this.fb.group({
            password: this.password,
            confirmPassword: this.confirmPassword,
        }, {validator: this.passwordConfirming});
        this.form = this.fb.group({
            displayName: this.displayName,
            email: this.email,
            phoneNumber: this.phoneNumber,
            passwords: this.passwords,
        });
    }

    passwordConfirming(group: FormGroup) {
        let pass = group.controls.password.value;
        let confirmPass = group.controls.confirmPassword.value;

        return pass === confirmPass ? null : { notSame: true };
    }

    onSubmit() {
        this.submitted = true;
    }

    register() {
        this.loading = true;
        const model: Register = {
            displayName: this.model.displayName,
            email: this.model.email,
            password: this.model.password,
            phoneNumber: this.model.phoneNumber,
        };

        this.authService.register(model)
            .subscribe(result => {
                this.loading = false;
                if (result.state == ApiResponseState.Success) {
                    this.router.navigate(['/']);
                }
                else {
                    this.hasError = true;
                    this.errorMessage = result.message;
                }
            });
    }
}
