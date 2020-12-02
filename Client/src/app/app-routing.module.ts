import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // {
  //   path: 'Auth',
  //   loadChildren: () => import('./auth/auth-routing.module').then(m => m.AuthRoutingModule)
  // },
  // {
  //   path: 'Shared',
  //   loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
  // },
  // {
  //   path: 'Ads',
  //   loadChildren: () => import('./ads/ads-routing.module').then(m => m.AdsRoutingModule)
  // },
  // {
  //   path: 'Categories',
  //   loadChildren: () => import('./categories/categories-routing.module').then(m => m.CategoriesRoutingModule)
  // },
  // {
  //   path: 'Users',
  //   loadChildren: () => import('./users/users-routing.module').then(m => m.UsersRoutingModule)
  // },
  // {
  //   path: '**',
  //   component: NotFoundComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
    //{ paramsInheritanceStrategy: 'always' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }


