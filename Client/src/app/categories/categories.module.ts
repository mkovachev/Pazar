import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesRoutingModule } from './categories-routing.module';
import { SharedModule } from '../shared/shared.module';
import { AllCategoriesComponent } from './all-categories/all-categories.component';

@NgModule({
    declarations: [AllCategoriesComponent],
    imports: [
        CommonModule,
        SharedModule,
        CategoriesRoutingModule
    ],
    exports: [AllCategoriesComponent]
})

export class CategoriesModule { }