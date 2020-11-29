import { Component, OnInit } from '@angular/core';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-my-ads',
  templateUrl: './my-ads.component.html',
  styleUrls: ['./my-ads.component.css']
})
export class MyAdsComponent implements OnInit {
  ads!: Array<Ad>;
  popUpOpen: boolean = false;
  id!: string;

  constructor(private adsService: AdsService) { }

  ngOnInit(): void {
    this.popUpOpen = false
    this.getMyAds()
  }

  getMyAds() {
    this.adsService.myAds().subscribe(ads => {
      this.ads = ads;
    })
  }

  assignAds(event: any) {
    this.ads = event['ads'];
  }

  delete() {
    this.adsService.delete(this.id).subscribe(res => {
      this.popUpOpen = false;
      this.getMyAds();
    })
  }

  changeAvailability(id: string) {
    this.adsService.changeAvailability(id).subscribe(res => {
      this.getMyAds()
    })
  }

  openModal(id: string) {
    this.popUpOpen = true;
    this.id = id;
  }

  cancelModal() {
    this.popUpOpen = false;
    this.id = '';
  }

}