import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AdsStatistics } from './ads-statistics.model';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  url = environment.statisticsUrl + 'adsstatistics/';

  constructor(private http: HttpClient) { }

  adsStatistics(): Observable<number> {
    return this.http.get<number>(this.url + 'adsoverview');
  }
}