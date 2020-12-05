import { Component, OnInit } from '@angular/core';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Category } from 'src/app/categories/category.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  categories!: Array<Category>;
  ads!: Array<Ad>;

  constructor(private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.categoryService.all().subscribe(res => {
      this.categories = res;
    });
  }

  adsPerCategory(id: string) {
    this.categoryService.ads(id).subscribe(res => {
      this.ads = res
    })
  }
}
