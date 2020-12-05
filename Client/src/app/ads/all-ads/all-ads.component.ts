import { Component, OnInit } from '@angular/core';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-all-ads',
  templateUrl: './all-ads.component.html',
})
export class AllAdsComponent implements OnInit {
  ads!: Array<Ad>

  constructor(
    private adsService: AdsService,) { }

  ngOnInit(): void {
    this.adsService.all().subscribe(res => {
      this.ads = res;
    })
  }
}
