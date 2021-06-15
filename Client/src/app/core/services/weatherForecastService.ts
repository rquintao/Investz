import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class WeatherForecastService{

    path: string = 'https://localhost:5001/api/WeatherForecast'

    constructor(private http: HttpClient) { }

    getInfo(){
        return this.http.get(this.path);
    }
}