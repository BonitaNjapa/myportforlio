import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


interface Stat
{
  name: string;
  value: string;
  icon: string;
  iconBg: string;
}


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  
  stats : Stat[] = [];

  constructor(private http: HttpClient) {
    const initStats = 
    [
        { name: 'Budget',      iconBg: "icon icon-shape bg-danger text-white text-lg rounded-circle", icon: "bi bi-credit-card",    value: '$750.90' },
        { name: 'New projects',iconBg: "icon icon-shape bg-primary text-white text-lg rounded-circle",icon: "bi bi-people",         value: '215' },
        { name: 'Total hours', iconBg: "icon icon-shape bg-info text-white text-lg rounded-circle",   icon: "bi bi-clock-history",  value: '1.400' },
        { name: 'Work load',   iconBg: "icon icon-shape bg-warning text-white text-lg rounded-circle",icon: "bi bi-minecart-loaded",value: '95%' },
    ];
    this.stats = initStats
  }  
}
