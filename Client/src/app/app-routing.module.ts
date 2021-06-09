import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WeatherForecastComponent } from './components/weather-forecast/weather-forecast.component';
import { AuthComponent } from './core/auth/auth.component';

const routes: Routes = 
[
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  { path: 'login', component : AuthComponent},
  { path: 'weather', component : WeatherForecastComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
