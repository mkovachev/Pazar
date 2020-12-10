import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  url = environment.statisticsUrl + 'ads/';

  constructor(private http: HttpClient) { }

  adsStatistics(): Observable<number> {
    return this.http.get<number>(this.url + 'total');
  }
}