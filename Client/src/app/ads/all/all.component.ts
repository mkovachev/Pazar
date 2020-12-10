import { Component, OnInit } from '@angular/core';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
})
export class AllComponent implements OnInit {
  ads!: Array<Ad>

  constructor(
    private adsService: AdsService,) { }

  ngOnInit(): void {
    this.adsService.all().subscribe(res => {
      this.ads = res;
    })
  }
}
