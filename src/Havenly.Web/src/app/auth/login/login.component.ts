// login.component.ts
import {Component} from '@angular/core';
import {AuthenticationService} from "../authentication.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  email!: string;
  password!: string;

  constructor(private authService: AuthenticationService) {
  }

  login() {
    this.authService.login(this.email, this.password);
  }

  register() {
    this.authService.register("username", this.email, this.password, "contactInfo");
  }
}
