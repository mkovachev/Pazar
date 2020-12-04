import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  url = `${environment.adsUrl}categories/`;
  urlWithoutSlash = this.url.slice(0, -1);

  constructor(private http: HttpClient) { }

  find(id: string): Observable<Category> {
    return this.http.get<Category>(this.url + id);
  }

  all(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.url);
  }

  create(category: Category): Observable<Category> {
    return this.http.post<Category>(this.url, category);
  }

  edit(id: string, category: Category): Observable<Category> {
    return this.http.put<Category>(this.url + id, category);
  }

  delete(id: string) {
    return this.http.delete(this.url + id);
  }
}
