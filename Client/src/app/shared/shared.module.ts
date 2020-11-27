import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgStackFormsModule } from '@ng-stack/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { SharedRoutingModule } from './shared-routing.module';
import { InterceptorService } from './interceptor.service';
import { ErrorInterceptorService } from './error-interceptor.service';

@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        SharedRoutingModule,
        NgStackFormsModule,
        ToastrModule.forRoot(),
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: InterceptorService,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: InterceptorService,
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
