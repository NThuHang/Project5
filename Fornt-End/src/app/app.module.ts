import { SharedModule } from 'src/app/shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './lib/error.interceptor';
import { JwtInterceptor } from './lib/jwt.interceptor';
import { TaikhoanComponent } from './ql-taikhoan/taikhoan/taikhoan.component';
import { DangkyComponent } from './login/dangky/dangky.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TaikhoanComponent,
    DangkyComponent,
  ],
  imports: [
    SharedModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [
     { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
     { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
