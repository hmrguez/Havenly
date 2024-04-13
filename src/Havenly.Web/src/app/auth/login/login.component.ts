// login.component.ts
import {Component} from '@angular/core';
import {AuthenticationService} from "../authentication.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  email!: string;
  password!: string;

  constructor(private authService: AuthenticationService, private router: Router) {
  }

  login() {
    this.authService.login(this.email, this.password).subscribe({next: _ => this.router.navigate([''])});
  }

  register() {
    this.authService.register("username", this.email, this.password, "contactInfo");
  }
}
