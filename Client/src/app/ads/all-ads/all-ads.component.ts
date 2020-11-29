import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-all-ads',
  templateUrl: './all-ads.component.html',
})
export class AllAdsComponent implements OnInit {
  ads!: Array<Ad>

  constructor(
    private adsService: AdsService,
    private router: Router) { }

  ngOnInit(): void {
    this.adsService.all().subscribe(res => {
      this.ads = res;
    })
  }

  adDetails(id: number) {
    this.router.navigate(['ads'], { queryParams: { id } });
  }
}
