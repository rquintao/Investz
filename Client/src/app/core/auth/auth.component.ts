import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.sass']
})
export class AuthComponent implements OnInit {

  pubPath: string = "/assets/pub/filler.jpg";
  logo: string = "/assets/logos/justLogo.PNG";

  constructor() { }

  ngOnInit() {
  }

}
