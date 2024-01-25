import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component'; 
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MainlayoutComponent } from './_layout/mainlayout/mainlayout.component';
import { AuthlayoutComponent } from './_layout/authlayout/authlayout.component';




export const routes: Routes = [
    {
        path: "", 
        component: MainlayoutComponent,
        children:[
            { path: "", component: HomeComponent, pathMatch: 'full' },
        ]
    },
    {
        path: "", 
        component: AuthlayoutComponent,
        children:[
            { path: "dashboard", component: DashboardComponent, pathMatch: 'full' },
        ]
    },
    { path: "login", component: LoginComponent },
    { path: "register", component: RegisterComponent },
    { path: '**', component: PageNotFoundComponent },
];
