import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchWeatherForecastsComponent } from './fetch-weather-forecasts.component';

describe('FetchWeatherForecastsComponent', () => {
  let component: FetchWeatherForecastsComponent;
  let fixture: ComponentFixture<FetchWeatherForecastsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FetchWeatherForecastsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchWeatherForecastsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
