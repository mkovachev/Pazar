import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AdsStatistics } from './ads-statistics.model';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {
  url = environment.statisticsUrl + 'statistics';

  constructor(private http: HttpClient) { }

  getStatistics(): Observable<AdsStatistics> {
    return this.http.get<AdsStatistics>(this.url);
  }
}
