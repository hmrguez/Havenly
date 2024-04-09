import {Component} from '@angular/core';
import {CheckboxModule} from "primeng/checkbox";
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CheckboxModule,
    CardModule,
    ButtonModule,
    InputTextModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

}
