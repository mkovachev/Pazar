import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllAdsComponent } from './all-ads/all-ads.component';
import { DetailsComponent } from './details/details.component';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';

const routes: Routes = [
    { path: 'ads', component: AllAdsComponent },
    { path: 'ads/create', component: CreateComponent, canActivate: [AuthGuard] },
    { path: 'ads/:id', component: DetailsComponent },
    { path: 'ads/myads', component: MyAdsComponent, canActivate: [AuthGuard] },
    { path: 'ads/edit/:id', component: EditComponent, canActivate: [AuthGuard] }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class AdsRoutingModule { }
