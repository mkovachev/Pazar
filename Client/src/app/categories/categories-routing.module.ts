import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DetailsComponent } from '../ads/details/details.component';
import { AdsPerCategoryComponent } from './ads-per-category/ads-per-category.component';
import { AllCategoriesComponent } from './all-categories/all-categories.component';

const routes: Routes = [
    { path: 'categories', component: AllCategoriesComponent },
    { path: 'categories/:id/details', component: DetailsComponent },
    { path: 'categories/:id/adsPerCategory', component: AdsPerCategoryComponent },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class CategoriesRoutingModule { }