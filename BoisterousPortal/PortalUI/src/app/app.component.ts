import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  constructor(http: HttpClient) {
    const url = `${environment.portalApiBase}/weatherforecast`;
    http.get<WeatherForecast[]>(url).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  title = 'PortalUI';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
