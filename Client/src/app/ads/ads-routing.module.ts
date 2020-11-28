import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { AllAdsComponent } from './all-ads/all-ads.component';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';


const routes: Routes = [
    { path: '', component: AllAdsComponent },
    { path: ':id', component: ViewComponent },
    { path: 'myads', component: MyAdsComponent, canActivate: [AuthGuard] },
    { path: 'create', component: CreateComponent, canActivate: [AuthGuard] },
    { path: ':id/edit', component: EditComponent, canActivate: [AuthGuard] },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class AdsRoutingModule { }
