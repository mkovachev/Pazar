import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

    constructor(
        private auth: AuthService,
        private router: Router) { }

    canActivate() {
        if (!this.auth.getToken()) {
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }
}
