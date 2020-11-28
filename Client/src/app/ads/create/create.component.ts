import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { ToastrService } from 'ngx-toastr';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';
import { Category } from '../../categories/category.model';
import { CategoriesService } from 'src/app/categories/categories.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
})
export class CreateComponent implements OnInit {
  adForm!: FormGroup<Ad>;
  categories!: Array<Category>;

  constructor(
    private fb: FormBuilder,
    private adsService: AdsService,
    private categoriesService: CategoriesService,
    public toastr: ToastrService,
    private router: Router) {
    this.categoriesService.getCategories().subscribe(res => {
      this.categories = res;
    })
  }

  ngOnInit(): void {
    this.adForm = this.fb.group<Ad>({
      title: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      imageUrl: [null, Validators.required],
      category: [null, Validators.required]
    })
  }

  create() {
    this.adsService.createAd(this.adForm.value).subscribe(res => {
      this.router.navigate(['ads', 'myads'])
    })
  }
}
