import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpEvent } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';

@Injectable({
    providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {

    constructor(public auth: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler,)
        : Observable<HttpEvent<any>> {
        const reqWithJwt = req.clone({
            setHeaders: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.auth.getToken()}`
            }
        });

        return next.handle(reqWithJwt);
    }
}