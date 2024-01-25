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
    this.http.get<Stat[]>('/stats').subscribe((data: Stat[]) => {
      this.stats = data;
    });
  }  
}
