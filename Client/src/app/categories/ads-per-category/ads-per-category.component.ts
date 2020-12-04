import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

@Component({
  selector: 'app-ads-per-category',
  templateUrl: './ads-per-category.component.html',
  styleUrls: ['./ads-per-category.component.css']
})
export class AdsPerCategoryComponent implements OnInit {
  category!: Category
  id!: string
  ads!: Array<Ad>

  constructor(
    private categoryService: CategoriesService,
    private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.categoryService.adsPerCategory(this.id).subscribe(res => {
      this.ads = res
      console.log(this.ads)
    })
  }

  ngOnInit(): void {
  }

}

// 
// 