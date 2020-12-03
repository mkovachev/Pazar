import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/users/users.service';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';
import { User } from '../../users/user.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  ad!: Ad;
  user!: User;
  adId!: string;
  userId!: string;

  constructor(
    private adService: AdsService,
    private userService: UsersService,
    private route: ActivatedRoute) {
    this.adId = this.route.snapshot.paramMap.get('id')!;
    this.userId = localStorage.getItem('userId')!;
    this.adService.find(this.adId).subscribe(ad => {
      this.ad = ad;
    }),
      this.userService.find(this.userId).subscribe(user => {
        this.user = user;
      })
  }

  ngOnInit(): void {
  }
}
