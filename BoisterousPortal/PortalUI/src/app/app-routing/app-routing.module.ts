import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { FetchWeatherForecastsComponent } from './../Components/fetch-weather-forecasts/fetch-weather-forecasts.component';
import { TemplatesListComponent } from './../Components/Templates/templates-list/templates-list.component';
import { ReportsListComponent } from './../Components/Reports/reports-list/reports-list.component';


const routes: Routes =
  [
    { path: '', component: FetchWeatherForecastsComponent, pathMatch: 'full' },
    { path: 'fetch-data', component: FetchWeatherForecastsComponent },
    { path: 'fetch', component: FetchWeatherForecastsComponent },
    { path: 'templates-list', component: TemplatesListComponent },
    { path: 'reports-list', component: ReportsListComponent },
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
