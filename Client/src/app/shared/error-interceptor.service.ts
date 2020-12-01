import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

    constructor(private toastrService: ToastrService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            retry(1),
            catchError((err) => {
                let message = ""
                if (err.status === 401) {
                    message = "401 Unauthorized"
                }
                else if (err.status === 404) {
                    message = "404 Not Found"
                }
                else if (err.status === 400) {
                    message = "400 Invalid input"
                }
                else {
                    message = "Unknown error"
                }
                this.toastrService.error(message)
                return throwError(err)
            })
        )
    }
}