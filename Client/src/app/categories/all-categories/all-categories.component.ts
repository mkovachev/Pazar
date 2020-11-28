import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
})
export class AllCategoriesComponent implements OnInit {
  categories!: Array<Category>;

  constructor(
    private categoriesService: CategoriesService,
    private router: Router) { }

  ngOnInit(): void {
    this.categoriesService.all().subscribe(res => {
      this.categories = res;
    });
  }

  goToAds(id: number) {
    this.router.navigate(['ads'], { queryParams: { category: id } });
  }

}
