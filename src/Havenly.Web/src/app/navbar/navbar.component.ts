import {Component} from '@angular/core';
import {AuthenticationService} from "../auth/authentication.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  constructor(public authService: AuthenticationService) {
  }
}
