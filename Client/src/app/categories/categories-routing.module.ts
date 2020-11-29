import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllCategoriesComponent } from './all-categories/all-categories.component';

const routes: Routes = [
    { path: 'categories', component: AllCategoriesComponent },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class CategoriesRoutingModule { }