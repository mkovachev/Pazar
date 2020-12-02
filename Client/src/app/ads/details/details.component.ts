import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  ad!: Ad;
  id!: string;

  constructor(private adService: AdsService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.adService.find(this.id).subscribe(ad => {
      this.ad = ad;
    });
  }

  // adDetails(id: number) {
  //   this.router.navigate(['ads'], { queryParams: { id } });
  // }
}
