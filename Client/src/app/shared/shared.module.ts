import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';

@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        ToastrModule.forRoot(),

    ],
    providers: [

    ],
    exports: [ReactiveFormsModule, FormsModule]
})
export class SharedModule { }
