import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  base64Image!: string;

  constructor(
    private fb: FormBuilder,
    private adsService: AdsService,
    private categoriesService: CategoriesService,
    public toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute) {
    this.adForm = this.fb.group<Ad>({
      id: [null, Validators.required],
      title: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      imageUrl: [null],
      isActive: [null, Validators.required],
      category: [null, Validators.required],
    }),
      this.categoriesService.all().subscribe(res => {
        this.categories = res;
      })
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.adsService.find(this.id).subscribe(ad => {
      console.log(ad.category)
      this.adForm = this.fb.group<Ad>({
        id: [ad.id],
        title: [ad.title],
        price: [ad.price],
        description: [ad.description],
        imageUrl: [ad.imageUrl],
        isActive: [ad.isActive],
        category: [ad.category],
      })
    })
  }

  edit() {
    this.adsService.edit(this.id, this.adForm.value).subscribe(res => {
      this.router.navigate(['ads', 'myads'])
      this.toastr.success("Success")
    })
  }

}
