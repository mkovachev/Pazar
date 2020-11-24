import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { CreateComponent } from './ads/create/create.component';
import { EditComponent } from './ads/edit/edit.component';
import { MyadsComponent } from './ads/myads/myads.component';
import { ViewComponent } from './ads/view/view.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    EditComponent,
    MyadsComponent,
    ViewComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // NgStackFormsModule,
    // ReactiveFormsModule,
    AuthenticationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
