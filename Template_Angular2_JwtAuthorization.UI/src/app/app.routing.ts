import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from "app/home/home.component";
import { AuthGuard } from "app/_directives/_guards/auth.guard";
import { LoginComponent } from "app/login/login.component";
import { RegisterComponent } from "app/register/register.component";
import { ModuleWithProviders } from "@angular/core";

export const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes, { useHash: true });