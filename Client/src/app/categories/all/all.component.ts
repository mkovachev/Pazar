import { Component, OnInit } from '@angular/core';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {
  categories!: Array<Category>;
  ads!: Array<Ad>;

  constructor(private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.categoryService.all().subscribe(res => {
      this.categories = res;
    });
  }

  adsInCategory(id: string) {
    this.categoryService.ads(id).subscribe(res => {
      this.ads = res
    })
  }

}
