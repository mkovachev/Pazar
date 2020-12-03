import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { AuthGuardService as AuthGuard } from '../shared/auth-guard.service';

const routes: Routes = [
    { path: 'users/profile', component: ProfileComponent, canActivate: [AuthGuard] },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class UsersRoutingModule { } 