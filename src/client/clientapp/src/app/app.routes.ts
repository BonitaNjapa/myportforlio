import { Routes } from '@angular/router';
import { RegisterComponent } from '../Components/register/register.component';
import { LoginComponent } from '../Components/login/login.component';
import { HomeComponent } from '../Components/home/home.component'; 
import { PageNotFoundComponent } from '../Components/page-not-found/page-not-found.component';




export const routes: Routes = [

    { path: "", component: HomeComponent },
    { path: "register", component: RegisterComponent },
    { path: "login", component: LoginComponent },
    { path: '**', component: PageNotFoundComponent },
];
