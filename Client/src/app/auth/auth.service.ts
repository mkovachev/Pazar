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
    url = `${environment.identityUrl}identity/`;

    constructor(private http: HttpClient) { }

    register(payload: any): Observable<any> {
        return this.http.post(this.url + 'register', payload);
    }

    login(payload: ExtractGroupValue<Login>): Observable<any> {
        return this.http.post(this.url + 'login', payload);
    }

    getToken() {
        return localStorage.getItem('token');
    }

    saveToken(token: string) {
        localStorage.setItem('token', token);
    }

    getUserId(): Observable<any> {
        return this.http.get(this.url + 'id');
    }

    saveUserId(userId: string) {
        localStorage.setItem('userId', userId);
    }
}
