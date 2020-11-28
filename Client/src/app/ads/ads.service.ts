import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Ad } from './ad.model';

@Injectable({
    providedIn: 'root'
})
export class AdsService {
    path = `${environment.adsUrl}ads/`;
    pathWithoutSlash = this.path.slice(0, -1);

    constructor(private http: HttpClient) { }

    find(id: string): Observable<Ad> {
        return this.http.get<Ad>(this.path + id);
    }

    all(): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.path);
    }

    myAds(): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(`${this.path}myads`);
    }

    create(ad: Ad): Observable<Ad> {
        return this.http.post<Ad>(this.path, ad);
    }

    edit(id: string, ad: Ad): Observable<Ad> {
        return this.http.put<Ad>(this.path + id, ad);
    }

    delete(id: string) {
        return this.http.delete(this.path + id);
    }

    search(queryString: string): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.pathWithoutSlash + queryString);
    }

    sort(queryString: string): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.pathWithoutSlash + queryString);
    }

    changeAvailability(id: any): Observable<boolean> {
        return this.http.put<boolean>(`${this.path + id}/changeAvailability`, {});
    }
}
