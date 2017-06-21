import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AlertComponent } from "app/_directives/alert/alert.component";
import { AuthGuard } from "app/_directives/_guards/auth.guard";
import { AlertService } from "app/_services/alert.service";
import { AuthenticationService } from "app/_services/authentication.service";
import { UserService } from "app/_services/user.service";
import { routing } from "app/app.routing";
import { WebApiService } from "app/_services/webApi.service";

// Application wide providers
const APP_PROVIDERS = [
  AuthGuard,
  AlertService,
  AuthenticationService,
  UserService,
  WebApiService
];

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    APP_PROVIDERS
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
