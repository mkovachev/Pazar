import { Component, OnInit } from '@angular/core';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';
import { NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-my-ads',
  templateUrl: './my-ads.component.html',
  styleUrls: ['./my-ads.component.css']
})
export class MyAdsComponent implements OnInit {
  closeResult!: string;
  modalOptions!: NgbModalOptions;

  ads!: Array<Ad>;
  userId!: string;
  adId!: string;

  constructor(
    private modalService: NgbModal,
    private adsService: AdsService) {
    this.userId = localStorage.getItem('userId')!;
    this.adsService.myAds(this.userId).subscribe(ads => {
      this.ads = ads;
    }),
      this.modalOptions = {
        backdrop: 'static',
        backdropClass: 'customBackdrop'
      }
  }

  ngOnInit(): void {
  }

  open(content: any) {
    this.modalService.open(content, this.modalOptions)
  }

  delete() {
    this.adsService.delete(this.adId).subscribe(res => {
    })
  }

  changeAvailability(id: string) {
    this.adsService.changeAvailability(id).subscribe(res => {
    })
  }

}