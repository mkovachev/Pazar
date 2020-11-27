import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdsService } from 'src/app/ads/ads.service';
import { Category } from 'src/app/ads/category.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  categories!: Array<Category>;

  constructor(
    private adsService: AdsService,
    private router: Router) { }

  ngOnInit(): void {
    // this.adsService.getCategories().subscribe(res => {
    //   this.categories = res;
    // });
  }

  goToAds(id: number) {
    this.router.navigate(['ads'], { queryParams: { category: id } });
  }

}
