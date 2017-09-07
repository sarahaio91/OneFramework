import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from '../shared/services/index';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private router: Router,
        private authService: AuthService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const userAuthenticated = this.authService.isAuthenticatedSubject;
        
        const value = userAuthenticated.getValue();

        console.log('Is authenticated?' + value);
        if(!value){
            this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        }

        return value;
    }
}
