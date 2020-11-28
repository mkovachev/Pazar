import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  path = `${environment.adsUrl}categories/`;
  pathWithoutSlash = this.path.slice(0, -1);

  constructor(private http: HttpClient) { }

  all(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(`${this.path}all`);
  }

  byId(id: string): Observable<Category> {
    return this.http.get<Category>(this.path + id);
  }

  create(category: Category): Observable<Category> {
    return this.http.post<Category>(this.path, category);
  }

  edit(id: string, category: Category): Observable<Category> {
    return this.http.put<Category>(this.path + id, category);
  }

  deleteC(id: string) {
    return this.http.delete(this.path + id);
  }
}
