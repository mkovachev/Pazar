import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Sort } from './sort.model';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { AdsService } from '../ads.service';
import { Router } from '@angular/router';
import { Ad } from '../ad.model';

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['./sort.component.css']
})
export class SortComponent implements OnInit {
  sortForm!: FormGroup<Sort>;
  @Output('emitter') emitter = new EventEmitter<Array<Ad>>();

  constructor(
    private fb: FormBuilder,
    private adsService: AdsService,
    private router: Router) { }

  ngOnInit(): void {
    this.sortForm = this.fb.group<Sort>({
      sortBy: ['', Validators.required],
      order: [''],
    })
  }

  sort() {
    //this.adsService.sort(this.getQueryUrl()).subscribe(ads => {
    //  this.emitter.emit(ads)
   // })
  }

  // getQueryUrl() {
  //   const params = new URLSearchParams();
  //   const formValue = this.sortForm.value;
  //   console.log(this.sortForm.value)
  //   for (const key in formValue) {
  //     if (!formValue[key]) {
  //       continue;
  //     }
  //     params.append(key, formValue[key]);
  //   }
  //   let query = params.toString()
  //   if (this.router.url.includes('myads')) {
  //     query = '/myads?' + params
  //   }
  //   else {
  //     query = '?' + params
  //   }
  //   return query;
  // }

}
