import { Component } from '@angular/core';
import {AuthenticationService} from "../auth/authentication.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  constructor(public authService: AuthenticationService) {
  }

}
