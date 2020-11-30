import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpEvent } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor{

    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler,)
        : Observable<HttpEvent<any>> {
        request = request.clone({
            setHeaders: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.getToken()}`
            }
        });

        return next.handle(request);
    }

    getToken() {
        return localStorage.getItem('token')
    }
}