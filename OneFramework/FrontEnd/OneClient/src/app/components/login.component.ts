import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';


@Component({
    selector: 'my-login',
    styleUrls: ['../../scss/components/login.component.scss'],
    templateUrl: '../../views/login.component.html',
})
export class LoginComponent implements OnInit {

    constructor(
        private router: Router,
        private userService: UserService,
        private fb: FormBuilder,
    ) {
        console.log('LoginComponent');
    }

    model : User;
    submitted = false;
    loginForm: FormGroup; // <--- heroForm is of type FormGroup

    ngOnInit(): void {
        const newUser : User = {
            email: "",
            password: ""
        };
        this.model = newUser;
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
        this.userService.login(this.model)
        .subscribe(result => {
            if(result.state == 1){
                console.log(result.message);
                let link = ['/dashboard'];
                this.router.navigate(link);
            }
        });
    }
}
