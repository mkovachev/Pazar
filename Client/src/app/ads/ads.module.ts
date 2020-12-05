import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DetailsComponent } from './details/details.component';
import { AdsRoutingModule } from './ads-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { AllAdsComponent } from './all-ads/all-ads.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [CreateComponent, EditComponent, DetailsComponent, MyAdsComponent, AllAdsComponent],
    imports: [
        CommonModule,
        SharedModule,
        AdsRoutingModule,
        NgbModule
    ],
    exports: []
})

export class AdsModule { }