import { Component } from '@angular/core';
import { IWeather } from './_model/weather.model';
import { WeatherService } from './_service/weather.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'weather-app';
  weatherData: IWeather[] = [];

  constructor(private weatherServicer: WeatherService) {}

  getWeather(): void {
    this.weatherServicer.getWeather().subscribe((resp) => {
      this.weatherData = resp;
    }, error => {
      alert('Error occurred. Check logs');
      console.log(error);
    });
  }
}
