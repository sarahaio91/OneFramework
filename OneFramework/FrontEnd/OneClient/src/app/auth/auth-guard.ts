import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { UserService } from '../shared/services/index';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private router: Router,
        private userService: UserService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const userAuthenticated = this.userService.isAuthenticatedSubject;
        
        const value = userAuthenticated.value;
        if(!value){
            this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        }

        return value;
    }
}
