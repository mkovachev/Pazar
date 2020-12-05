import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesRoutingModule } from './categories-routing.module';
import { SharedModule } from '../shared/shared.module';
import { AllComponent } from './all/all.component';
import { DetailsComponent } from './details/details.component';
import { AdsComponent } from './ads/ads.component';

@NgModule({
    declarations: [AllComponent, DetailsComponent, AdsComponent],
    imports: [
        CommonModule,
        SharedModule,
        CategoriesRoutingModule
    ],
    exports: [AllComponent, DetailsComponent, AdsComponent]
})

export class CategoriesModule { }