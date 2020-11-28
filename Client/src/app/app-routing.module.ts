import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdsModule } from './ads/ads.module';

const routes: Routes = [
  {
    path: 'Auth',
    loadChildren: () => import('./auth/auth-routing.module').then(m => m.AuthRoutingModule)
  },
  {
    path: 'Shared',
    loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
  },
  {
    path: 'Ads',
    loadChildren: () => import('./ads/ads.module').then(m => m.AdsModule)
  },
  {
    path: 'Categories',
    loadChildren: () => import('./categories/categories-routing.module').then(m => m.CategoriesRoutingModule)
  },
  {
    path: 'Users',
    loadChildren: () => import('./users/users-routing.module').then(m => m.UsersRoutingModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
