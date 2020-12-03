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
    userPath: string = `${environment.identityUrl}identity/`
    constructor(private http: HttpClient) { }

    find(id: string): Observable<User> {
        return this.http.get<User>(this.userPath + id)
    }

    edit(id: string, payload: User): Observable<any> {
        return this.http.put(this.userPath + id, payload)
    }

    delete(): Observable<any> {
        return this.http.delete(this.userPath + 'delete')
    }

    changePassword(payload: PasswordChange): Observable<any> {
        return this.http.put(this.userPath + 'changePassword', payload);
    }
}