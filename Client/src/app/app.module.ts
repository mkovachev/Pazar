import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgStackFormsModule } from '@ng-stack/forms';

import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';
import { AdsModule } from './ads/ads.module';
import { CategoriesModule } from './categories/categories.module';
import { UsersModule } from './users/users.module';




@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgStackFormsModule,
    SharedModule,
    AuthModule,
    AdsModule,
    CategoriesModule,
    UsersModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
