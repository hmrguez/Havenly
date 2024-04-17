import {Component} from '@angular/core';
import {Tenant} from "../common/tenant";
import {genderMap} from "../common/gender";

@Component({
  selector: 'app-tenants',
  templateUrl: './tenants.component.html',
  styleUrls: ['./tenants.component.scss']
})
export class TenantsComponent {
  protected readonly genderMap = genderMap;
  tenants: Tenant[] = [];

  constructor() {
  }
}
