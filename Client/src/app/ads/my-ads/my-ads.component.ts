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
  userId!: string;
  adId!: string;

  constructor(private adsService: AdsService) {
    this.userId = localStorage.getItem('userId')!;
    this.adsService.myAds(this.userId).subscribe(ads => {
      this.ads = ads;
      console.log(ads)
    })
  }

  ngOnInit(): void {
    this.popUpOpen = false
    //this.getMyAds()
  }

  assignAds(event: any) {
    this.ads = event['ads'];
  }

  delete() {
    this.adsService.delete(this.adId).subscribe(res => {
      this.popUpOpen = false;
    })
  }

  changeAvailability(id: string) {
    this.adsService.changeAvailability(id).subscribe(res => {
    })
  }

  openModal(id: string) {
    this.popUpOpen = true;
    this.adId = id;
  }

  cancelModal() {
    this.popUpOpen = false;
    this.adId = '';
  }

}