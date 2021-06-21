import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/authService';

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

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.InitForm();
  }

  login(){
    let user = this.loginForm.value.username;
    let password = this.loginForm.value.password;

    this.authService.login(user, password).subscribe(data => {
      console.log("sucess");
    }, error => {
      console.log(error);
    });
  }

  private InitForm(){
    this.loginForm = new FormGroup({
      username: new FormControl(this.usernameForm, Validators.nullValidator),
      password: new FormControl(this.passwordForm, Validators.nullValidator)
    });
  }

}
