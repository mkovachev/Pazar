import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Profile } from './profile.model';

@Injectable({
    providedIn: 'root'
})
export class ProfileService {
    userPath: string = environment.usersUrl + 'Users/'
    constructor(private http: HttpClient) { }

    getUser(id: string): Observable<Profile> {
        return this.http.get<Profile>(this.userPath + id)
    }

    editUser(id: string, payload: any): Observable<null> {
        return this.http.put<null>(this.userPath + id, payload)
    }

    changePassword(payload: any) {
        return this.http.put(environment.identityUrl + 'identity/changePassword', payload);
    }
}