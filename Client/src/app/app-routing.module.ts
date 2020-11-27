import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import '@angular/platform-browser';
import '@angular/platform-browser-dynamic'

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./authentication/authentication-routing.module').then(m => m.AuthenticationRoutingModule)
  },
  {
    path: 'ads',
    loadChildren: () => import('./ads/ads-routing.module').then(m => m.AdsRoutingModule)
  },
  {
    path: 'users',
    loadChildren: () => import('./users/users-routing.module').then(m => m.UsersRoutingModule)
  },
  // {
  //   path: '',
  //   loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
