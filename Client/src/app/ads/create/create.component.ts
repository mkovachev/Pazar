import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { ToastrService } from 'ngx-toastr';
import { AdsService } from '../ads.service';
import { Category } from '../../categories/category.model';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Ad } from '../ad.model';


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
    this.adForm = this.fb.group<Ad>({
      id: [null],
      title: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      imageUrl: [null, Validators.required],
      isActive: [null, Validators.required],
      categoryId: [null, Validators.required],
    }),
      this.categoriesService.all().subscribe(res => {
        this.categories = res;
      })
  }

  ngOnInit(): void {
  }

  create() {
    this.adsService.create(this.adForm.value).subscribe(res => {
      this.router.navigate(['ads', 'myads'])
      this.toastr.success("Success")
    })
  }
}
