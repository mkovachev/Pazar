import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ExtractGroupValue } from '@ng-stack/forms/lib/types';
import { LoginFormModel } from './login/login.model';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    registerPath = `${environment.identityApiUrl}identity/register`;
    loginPath = `${environment.identityApiUrl}identity/login`;
    createUserPath = `${environment.adsApiUrl}users`;
    userIdPath = `${environment.adsApiUrl}user/id`;

    constructor(private http: HttpClient) { }

    register(payload: any): Observable<any> {
        return this.http.post(this.registerPath, payload);
    }

    createUser(payload: any): Observable<any> {
        return this.http.post(this.createUserPath, payload);
    }

    login(payload: ExtractGroupValue<LoginFormModel>): Observable<any> {
        return this.http.post(this.loginPath, payload);
    }

    getUserId(): Observable<any> {
        return this.http.get(this.userIdPath);
    }

    setToken(token: string): void {
        localStorage.setItem('token', token);
    }

    setId(userId: string): void {
        localStorage.setItem('userId', userId);
    }
}
