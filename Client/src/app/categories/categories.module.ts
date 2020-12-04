import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesRoutingModule } from './categories-routing.module';
import { SharedModule } from '../shared/shared.module';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { DetailsComponent } from './details/details.component';
import { AdsPerCategoryComponent } from './ads-per-category/ads-per-category.component';

@NgModule({
    declarations: [AllCategoriesComponent, DetailsComponent, AdsPerCategoryComponent],
    imports: [
        CommonModule,
        SharedModule,
        CategoriesRoutingModule
    ],
    exports: [AllCategoriesComponent]
})

export class CategoriesModule { }