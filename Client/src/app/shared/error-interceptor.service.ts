import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
} from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError, finalize, retry } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root',
})
export class ErrorInterceptorService implements HttpInterceptor {
    constructor(private toastrService: ToastrService) { }
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
        console.log(req);
        return next.handle(req).pipe(
            //retry(1),
            catchError((err) => {
                let msg = '';
                if (err.status === 401) {
                    msg = '401 Unauthorized';
                } else if (err.status === 404) {
                    msg = '404 Not Found';
                } else if (err.status === 400) {
                    msg = '400 Invalid input';
                } else {
                    msg = 'Unknown error';
                }
                this.toastrService.error(msg);
                return throwError(err);
            })
        );
    }
}
