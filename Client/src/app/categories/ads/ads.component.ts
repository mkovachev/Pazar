import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ad } from 'src/app/ads/ad.model';
import { CategoriesService } from '../categories.service';

@Component({
  selector: 'app-ads',
  templateUrl: './ads.component.html',
  styleUrls: ['./ads.component.css']
})
export class AdsComponent implements OnInit {
  id!: string
  ads!: Array<Ad>

  constructor(
    private categoryService: CategoriesService,
    private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.categoryService.ads(this.id).subscribe(res => {
      this.ads = res
    })
  }

  ngOnInit(): void {
  }

}