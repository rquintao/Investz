import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.sass']
})
export class AuthComponent implements OnInit {

  loginForm: FormGroup;

  private usernameForm : string = '';
  private passwordForm : string = '';

  pubPath: string = "/assets/pub/filler.jpg";
  logo: string = "/assets/logos/justLogo.PNG";

  constructor() { }

  ngOnInit() {
    this.InitForm();
  }

  onSubmit(){
    console.log(this.loginForm.value);
  }

  private InitForm(){
    this.loginForm = new FormGroup({
      username: new FormControl(this.usernameForm, Validators.required),
      password: new FormControl(this.passwordForm, Validators.required)
    });
  }

}
