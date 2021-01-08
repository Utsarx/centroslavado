import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NbAuthService } from '@nebular/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  private  token: string = '';
  constructor(private authService:NbAuthService) {
    this.authService.getToken().subscribe(t=> {
        console.log(t.getValue());
        this.token = t.getValue();
    })
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  
     

    let request = req;

    if (this.token) {
      request = req.clone({
        setHeaders: {
          authorization: `Bearer ${ this.token }`
        }
      });
    }

    return next.handle(request);
  }

}