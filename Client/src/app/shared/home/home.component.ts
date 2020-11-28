import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from 'src/app/categories/categories.service';
import { Category } from 'src/app/categories/category.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
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
