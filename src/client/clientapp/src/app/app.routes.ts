import { Routes } from '@angular/router';
import { RegisterComponent } from '../Components/Register/register/register.component';
import { LoginComponent } from '../Components/Login/login/login.component';
import { HomeComponent } from '../Components/home/home.component'; 
import { PageNotFoundComponent } from '../Components/page-not-found/page-not-found.component';




export const routes: Routes = [

    { path: "", component: HomeComponent },
    { path: "Register", component: RegisterComponent },
    { path: "Login", component: LoginComponent },
     { path: '**', component: PageNotFoundComponent },
];
