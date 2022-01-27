import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { FetchWeatherForecastsComponent } from './../Components/fetch-weather-forecasts/fetch-weather-forecasts.component';


const routes: Routes =
  [
    { path: '', component: FetchWeatherForecastsComponent, pathMatch: 'full' },
    { path: 'fetch-data', component: FetchWeatherForecastsComponent },
    { path: 'fetch', component: FetchWeatherForecastsComponent },
  ];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
