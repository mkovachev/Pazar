import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./authentication/auth-routing.module').then(m => m.AuthRoutingModule)
  },
  {
    path: 'ads',
    loadChildren: () => import('./ads/ads-routing.module').then(m => m.AdsRoutingModule)
  },
  {
    path: 'users',
    loadChildren: () => import('./users/users-routing.module').then(m => m.UsersRoutingModule)
  },
  {
    path: 'shared',
    loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
