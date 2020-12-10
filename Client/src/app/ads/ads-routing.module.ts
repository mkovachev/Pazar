import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllComponent } from './all/all.component';
import { DetailsComponent } from './details/details.component';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';

const routes: Routes = [
    { path: 'ads', component: AllComponent },
    { path: 'ads/create', component: CreateComponent, canActivate: [AuthGuard] },
    { path: 'ads/myads', component: MyAdsComponent, canActivate: [AuthGuard] },
    { path: 'ads/:id/edit', component: EditComponent, canActivate: [AuthGuard] },
    { path: 'ads/:id/changeAvailability', component: MyAdsComponent, canActivate: [AuthGuard] },
    { path: 'ads/:id', component: DetailsComponent },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class AdsRoutingModule { }
