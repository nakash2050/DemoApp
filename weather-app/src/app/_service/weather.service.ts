import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IWeather } from '../_model/weather.model';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  apiUrl = `${environment.apiUrl}/weatherforecast/`;

  constructor(private http: HttpClient) { }

  getWeather(): Observable<IWeather[]> {
    return this.http.get<IWeather[]>(this.apiUrl);
  }
}
