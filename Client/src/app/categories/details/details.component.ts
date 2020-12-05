import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  category!: Category;
  id!: string;


  constructor(
    private categoryService: CategoriesService,
    private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.categoryService.find(this.id).subscribe(res => {
      this.category = res;
    })
  }

  ngOnInit(): void {
  }
}
