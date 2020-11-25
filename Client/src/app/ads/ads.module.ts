import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
import { AdsRoutingModule } from './ads-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { AllAdsComponent } from './all-ads/all-ads.component';

@NgModule({
    declarations: [CreateComponent, EditComponent, MyAdsComponent, ViewComponent, AllAdsComponent],
    imports: [
        CommonModule,
        SharedModule,
        AdsRoutingModule,
    ],
    exports: [CreateComponent, EditComponent, MyAdsComponent, ViewComponent, AllAdsComponent]
})

export class AdsModule { }