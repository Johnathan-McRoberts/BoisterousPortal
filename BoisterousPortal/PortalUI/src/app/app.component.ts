import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

import { environment } from '../environments/environment';


import { SideNavigationListComponent } from "./Components/Layout/side-navigation-list/side-navigation-list.component";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public selectedMenu: string = SideNavigationListComponent.defaultMenuItemText;

  onSelectedMenuItem(selection: string): void {
    this.selectedMenu = selection;
  }



  public title = 'PortalUI';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
