import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Category } from './category.model';
import { Ad } from './ad.model';

@Injectable({
    providedIn: 'root'
})
export class CarsService {
    path = `${environment.adsApiUrl}ads/`;
    carPathWithoutSlash = this.path.slice(0, -1);

    constructor(private http: HttpClient) { }

    getAds(): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.path);
    }

    getMyAds(): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(`${this.path}myads`);
    }

    getAd(id: string): Observable<Ad> {
        return this.http.get<Ad>(this.path + id);
    }

    createAd(ad: Ad): Observable<Ad> {
        return this.http.post<Ad>(this.path, ad);
    }

    editAd(id: string, ad: Ad): Observable<Ad> {
        return this.http.put<Ad>(this.path + id, ad);
    }

    deleteAd(id: string) {
        return this.http.delete(this.path + id);
    }

    getCategories(): Observable<Array<Category>> {
        return this.http.get<Array<Category>>(`${this.path}categories`);
    }

    search(queryString: string): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.carPathWithoutSlash + queryString);
    }

    sort(queryString: string): Observable<Array<Ad>> {
        return this.http.get<Array<Ad>>(this.carPathWithoutSlash + queryString);
    }

    changeAvailability(id: any): Observable<boolean> {
        return this.http.put<boolean>(`${this.path + id}/changeAvailability`, {});
    }
}
