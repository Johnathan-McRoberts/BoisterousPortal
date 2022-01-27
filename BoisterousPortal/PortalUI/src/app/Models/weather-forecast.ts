interface IWeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export class WeatherForecast implements IWeatherForecast {
  constructor(
    public date: string,
    public temperatureC: number,
    public temperatureF: number,
    public summary: string) { }
}
