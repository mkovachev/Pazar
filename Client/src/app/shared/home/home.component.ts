import { Component, OnInit } from '@angular/core';
import { AdsService } from 'src/app/ads/ads.service';
import { Category } from 'src/app/ads/category.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  categories!: Array<Category>;

  constructor(private adsService: AdsService) { }

  ngOnInit(): void {
    this.adsService.getCategories().subscribe(res => {
      this.categories = res;
    });
  }

}
