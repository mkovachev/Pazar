import { Component, OnInit } from '@angular/core';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-my-ads',
  templateUrl: './my-ads.component.html',
  styleUrls: ['./my-ads.component.css']
})
export class MyAdsComponent implements OnInit {
  closeResult!: string;

  ads!: Array<Ad>;
  userId!: string;
  adId!: number;

  constructor(
    private modalService: NgbModal,
    public toastr: ToastrService,
    private adsService: AdsService) {
    this.userId = localStorage.getItem('userId')!;
    this.adsService.myAds(this.userId).subscribe(ads => {
      this.ads = ads;
    })
  }

  ngOnInit(): void {
  }

  openDelete(content: any, id: number) {
    this.modalService.open(content)
    this.adId = id
  }

  delete() {
    this.adsService.delete(this.adId).subscribe(res => {
      this.toastr.info("Your ad was deleted")
      location.reload()
    })
  }

  changeAvailability(id: string) {
    this.adsService.changeAvailability(id).subscribe(res => {
      location.reload()
    })
  }

}