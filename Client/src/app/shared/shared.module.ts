import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { SharedRoutingModule } from './shared-routing.module';
import { JwtInterceptorService } from './jwt-interceptor.service';
import { ErrorInterceptorService } from './error-interceptor.service';
import { PopUpComponent } from './pop-up/pop-up.component';

@NgModule({
    declarations: [HomeComponent, PopUpComponent],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        ToastrModule.forRoot(),
        SharedRoutingModule,
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptorService,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ErrorInterceptorService,
            multi: true
        },
    ],
    exports: [ReactiveFormsModule, FormsModule]
})
export class SharedModule { }
