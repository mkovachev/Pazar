import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Ad } from './ad.model';

@Injectable({
    providedIn: 'root'
})
export class AdsService {
    url = environment.adsUrl + 'ads/';
    urlWithoutSlash = this.url.slice(0, -1);

    constructor(private http: HttpClient) { }

    find(id: string): Observable<Ad> {
        return this.http.get<Ad>(this.url + id);
    }

    all(): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.url);
    }

    myAds(userId: string): Observable<Array<Ad>> {
        const params = new HttpParams().set("userId", userId);
        return this.http.get<Array<Ad>>(this.url + 'myads', { params });
    }

    create(ad: Ad): Observable<Ad> {
        return this.http.post<Ad>(this.url, ad);
    }

    edit(id: string, ad: Ad): Observable<Ad> {
        return this.http.put<Ad>(this.url + id, ad);
    }

    delete(id: any): Observable<any> {
        return this.http.delete(this.url + id);
    }

    changeAvailability(id: any): Observable<boolean> {
        return this.http.put<boolean>(`${this.url + id}/changeAvailability`, {});
    }
}
