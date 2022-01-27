import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from './../../../environments/environment';

import { WeatherForecast } from './../../Models/weather-forecast';


@Component({
  selector: 'app-fetch-weather-forecasts',
  templateUrl: './fetch-weather-forecasts.component.html',
  styleUrls: ['./fetch-weather-forecasts.component.css']
})
export class FetchWeatherForecastsComponent implements OnInit {

  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient
    //, @Inject('BASE_URL') baseUrl: string
  ) {
    const url = `${environment.portalApiBase}/weatherforecast`;
    http.get<WeatherForecast[]>(url).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
