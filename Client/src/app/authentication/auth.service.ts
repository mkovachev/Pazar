import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Login } from './login/login.model';
import { ExtractGroupValue } from '@ng-stack/forms/lib/types';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    registerPath = `${environment.identityUrl}identity/register`;
    loginPath = `${environment.identityUrl}identity/login`;
    createUserPath = `${environment.usersUrl}users`;
    userIdPath = `${environment.usersUrl}user/id`;

    constructor(private http: HttpClient) { }

    register(payload: any): Observable<any> {
        return this.http.post(this.registerPath, payload);
    }

    createUser(payload: any): Observable<any> {
        return this.http.post(this.createUserPath, payload);
    }

    login(payload: ExtractGroupValue<Login>): Observable<any> {
        return this.http.post(this.loginPath, payload);
    }

    getUserId(): Observable<any> {
        return this.http.get(this.userIdPath);
    }

    // get user id
    setId(userId: string) {
        localStorage.setItem('userId', userId);
    }

    // save token
    setToken(token: string) {
        localStorage.setItem('token', token);
    }

}
