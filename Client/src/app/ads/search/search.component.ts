import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Category } from 'src/app/categories/category.model';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';
import { Search } from './search.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchForm!: FormGroup<Search>
  categories!: Array<Category>;
  category!: number;
  @Output('emitter') emitter = new EventEmitter<Array<Ad>>();

  constructor(
    private fb: FormBuilder,
    private adsService: AdsService,
    private categoriesService: CategoriesService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.searchForm = this.fb.group<Search>({
      title: ['', Validators.required],
      user: [''],
      category: [this.category, Validators.required],
      minPrice: [null, Validators.required],
      maxPrice: [null, Validators.required],
    })
    this.route.queryParams.subscribe(params => {
      this.category = params['category'];
      this.searchForm.patchValue({ category: this.category })
      console.log(this.searchForm)
      //this.search()
    });
    this.categoriesService.all().subscribe(res => {
      this.categories = res
    })
  }

  search() {
    //var queryString = this.getQueryUrl();
    //this.adsService.search(queryString).subscribe(cars => {
     // this.emitter.emit(cars)
    //})
  }

  // getQueryUrl() {
  //   const params = new URLSearchParams();
  //   const formValue = this.searchForm.value;
  //   console.log(this.searchForm.value)
  //   for (const key in formValue) {
  //     if (!formValue[key]) {
  //       continue;
  //     }
  //     params.append(key, formValue[key]);
  //   }

  //   var query = params.toString()
  //   if (this.router.url.includes('myads')) {
  //     query = '/myads?' + params
  //   }
  //   else {
  //     query = '?' + params
  //   }
  //   return query;
  // }

}
