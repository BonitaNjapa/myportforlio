import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component'; 
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';




export const routes: Routes = [
    { path: "", component: HomeComponent },
    { path: "dashboard", component: DashboardComponent },
    { path: "register", component: RegisterComponent },
    { path: "login", component: LoginComponent },
    { path: '**', component: PageNotFoundComponent },
];
