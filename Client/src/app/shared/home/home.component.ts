import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Category } from 'src/app/categories/category.model';
import { AdsStatistics } from '../statistics/ads-statistics.model';
import { StatisticsService } from '../statistics/statistics.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  categories!: Array<Category>;
  ads!: Array<Ad>;
  statistics!: AdsStatistics;

  constructor(
    private categoryService: CategoriesService,
    private statisticsService: StatisticsService) { }

  ngOnInit(): void {
    this.categoryService.all().subscribe(res => {
      this.categories = res;
    });

    // this.statisticsService.adsStatistics().subscribe(res => {
    //   this.statistics = res;
    // });
  }
}
