import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyAdsComponent } from '../my-ads/my-ads.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';
import { AllAdsComponent } from '../all-ads/all-ads.component';


const routes: Routes = [
    { path: '', component: AllAdsComponent },
    { path: 'myads', component: MyAdsComponent, canActivate: [AuthGuard] },
    { path: 'create', component: CreateComponent, canActivate: [AuthGuard] },
    { path: ':id', component: ViewComponent },
    { path: ':id/edit', component: EditComponent, canActivate: [AuthGuard] },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class AdsRoutingModule { }
