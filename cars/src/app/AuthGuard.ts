
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({ providedIn: 'root' })

export class AuthGuard implements CanActivate {

    isLoggedIn = false;

    constructor(private router: Router) {      
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        debugger
        if (localStorage.getItem('UserToken'))
        {
            return true;
        }
        else {
            this.router.navigate(['/login']);
            return false;
        }
    }
}