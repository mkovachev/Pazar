import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DetailsComponent } from './details/details.component';
import { AdsComponent } from '../categories/ads/ads.component';
import { AllComponent } from './all/all.component';

const routes: Routes = [
    { path: 'categories', component: AllComponent },
    { path: 'categories/:id', component: DetailsComponent },
    { path: 'categories/:id/ads', component: AdsComponent },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class CategoriesRoutingModule { }