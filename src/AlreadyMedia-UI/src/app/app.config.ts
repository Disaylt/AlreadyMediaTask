import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { ErrorHttpInterceptor } from './core/interceptor/error-http-interceptor';
import { HostHttpInterceptor } from './core/interceptor/host-http-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideAnimationsAsync(),
    provideHttpClient(withInterceptorsFromDi()),
    {provide : HTTP_INTERCEPTORS, useClass : ErrorHttpInterceptor, multi: true},
    {provide : HTTP_INTERCEPTORS, useClass : HostHttpInterceptor, multi: true}
  ]
};
