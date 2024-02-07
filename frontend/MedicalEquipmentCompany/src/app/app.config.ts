import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { JwtInterceptor } from '../jwt/jwt.interceptor';
import { provideToastr } from 'ngx-toastr';


export const appConfig: ApplicationConfig = {
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },provideRouter(routes), provideAnimations(),
  provideToastr(), provideAnimations(),provideHttpClient(withInterceptorsFromDi(),)]
};
