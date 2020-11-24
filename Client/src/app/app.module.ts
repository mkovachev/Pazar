import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { CreateComponent } from './ads
import { ProfileComponent } from './users/profile/profile.component';
import { MyAdsComponent } from './my-ads/my-ads.component';
import { AllAdsComponent } from './all-ads/all-ads.component';

@NgModule({
  declarations: [
    AppComponent,
    MyAdsComponent,
    AllAdsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthenticationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
