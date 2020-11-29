import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { ToastrService } from 'ngx-toastr';
import { AdCreate } from '../adcreate.model';
import { AdsService } from '../ads.service';
import { Category } from '../../categories/category.model';
import { CategoriesService } from 'src/app/categories/categories.service';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
})
export class CreateComponent implements OnInit {
  adForm!: FormGroup<AdCreate>;
  categories!: Array<Category>;

  constructor(
    private fb: FormBuilder,
    private adsService: AdsService,
    private categoriesService: CategoriesService,
    public toastr: ToastrService,
    private router: Router) {
    this.categoriesService.all().subscribe(res => {
      this.categories = res;
    })
  }

  ngOnInit(): void {
    this.adForm = this.fb.group<AdCreate>({
      //id: [null],
      title: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      imageUrl: [null, Validators.required],
      category: [null, Validators.required],
      //isActive: [null],
      //user: Profile
    })
  }

  create() {
    this.adsService.create(this.adForm.value).subscribe(res => {
      console.log(this.adForm.value)
      this.router.navigate(['ads', 'myads'])
      this.toastr.success("Success")
    })
  }
}
