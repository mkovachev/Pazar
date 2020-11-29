import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { ToastrService } from 'ngx-toastr';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Category } from 'src/app/categories/category.model';
import { Ad } from '../ad.model';
import { AdsService } from '../ads.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  adForm!: FormGroup<Ad>;
  categories!: Array<Category>;
  id!: string;
  ad!: Ad;

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
    this.adForm = this.fb.group<Ad>({
      id: [null],
      title: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      imageUrl: [null, Validators.required],
      category: [null, Validators.required],
      isActive: [null],
      //user: Profile
    })
  }

  edit() {
    this.adsService.edit(this.id, this.adForm.value).subscribe(res => {
      this.router.navigate(['ads', 'myads'])
      this.toastr.success("Success")
    })
  }

}
