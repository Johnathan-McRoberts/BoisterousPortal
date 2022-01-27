import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AngularMaterialModule } from './angular-material/angular-material.module';
import { AppRoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from './app.component';
import { FetchWeatherForecastsComponent } from './Components/fetch-weather-forecasts/fetch-weather-forecasts.component';
import { LayoutComponent } from './Components/Layout/layout/layout.component';
import { SideNavigationListComponent } from './Components/Layout/side-navigation-list/side-navigation-list.component';
import { NavigationHeaderComponent } from './Components/Layout/navigation-header/navigation-header.component';
import { TemplatesListComponent } from './Components/Templates/templates-list/templates-list.component';
import { ReportsListComponent } from './Components/Reports/reports-list/reports-list.component';

@NgModule({
  declarations: [
    AppComponent,
    FetchWeatherForecastsComponent,
    LayoutComponent,
    SideNavigationListComponent,
    NavigationHeaderComponent,
    TemplatesListComponent,
    ReportsListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,

    AngularMaterialModule,

    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
