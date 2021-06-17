import { Component, OnInit } from '@angular/core';
import { WeatherForecastService } from 'src/app/core/services/weatherForecastService';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.sass']
})
export class WeatherForecastComponent implements OnInit {

  public json:string;

  constructor(private weatherService: WeatherForecastService) { }

  ngOnInit() {
    this.weatherService.getInfo().subscribe(result => {
      console.log(result);
      this.json = JSON.stringify(result);
    })
  }

}
