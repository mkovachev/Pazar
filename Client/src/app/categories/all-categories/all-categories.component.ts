import { Component, OnInit } from '@angular/core';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {
  categories!: Array<Category>;
  ads!: Array<Ad>;

  constructor(private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.categoryService.all().subscribe(res => {
      this.categories = res;
    });
  }

  adsPerCategory(id: string) {
    this.categoryService.adsPerCategory(id).subscribe(res => {
      this.ads = res
    })
  }

}
