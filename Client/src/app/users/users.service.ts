import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { PasswordChange } from './password.model';

@Injectable({
    providedIn: 'root'
})
export class UsersService {
    url: string = `${environment.identityUrl}identity/`
    
    constructor(private http: HttpClient) { }

    find(id: string): Observable<User> {
        return this.http.get<User>(this.url + id)
    }

    edit(id: string, payload: User): Observable<any> {
        return this.http.put(this.url + id, payload)
    }

    delete(): Observable<any> {
        return this.http.delete(this.url + 'delete')
    }

    changePassword(payload: PasswordChange): Observable<any> {
        return this.http.put(this.url + 'changePassword', payload);
    }
}