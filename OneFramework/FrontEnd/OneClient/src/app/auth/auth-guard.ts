import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { UserService } from '../services/index';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private router: Router,
        private userService: UserService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const userAuthenticated = this.userService.isAuthenticated.take(1);
        
        console.log(this.router);
        console.log(userAuthenticated);
        // let link = ['/dashboard'];
        // this.router.navigate(link);
        // this.router.navigate(['/login']);
        if(true){
            // console.log('redirecting');
            // this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
            return false;
        }

        // return this.userService.isAuthenticated.take(1);
    }
}
