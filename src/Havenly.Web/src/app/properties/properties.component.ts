import {Component} from '@angular/core';
import {Property} from "../common/property";
import {propertyTypeMap} from "../common/propertyType";
import {PropertiesService} from "./properties.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {SelectItem} from "primeng/api";
import {Tenant} from "../common/tenant";
import {LeasesService} from "../leases/leases.service";

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrl: './properties.component.scss'
})
export class PropertiesComponent {

  properties: Property[] = [];
  addTenantFlag = false;
  selectedProperty: Property | undefined;
  protected readonly propertyTypeMap = propertyTypeMap;
  tenantForm!: FormGroup;
  genders: any[] | undefined = [
    <SelectItem>{label: 'Male', value: "MALE"},
    <SelectItem>{label: 'Female', value: "FEMALE"},
    <SelectItem>{label: 'Other', value: "UNDEFINED"},
  ];

  constructor(private propertiesService: PropertiesService, private leaseService: LeasesService) {

    this.tenantForm = new FormGroup({
      name: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      contactInfo: new FormControl('', Validators.required),
      gender: new FormControl('', Validators.required),
      averageSalary: new FormControl('', [Validators.required, Validators.min(0)]),
      age: new FormControl('', [Validators.required, Validators.min(0)]),
      rent: new FormControl('', [Validators.required, Validators.min(0)]),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      deposit: new FormControl('', [Validators.required, Validators.min(0)])
    });

    this.propertiesService.getPropertiesByOwner('c5d853ef-97aa-46dc-824c-95e0dbb0f94c')
      .subscribe({
        next: value => {
          console.log(value)
          this.properties = value.data.propertiesByOwner
        }
      });
  }

  showProperty(property: any) {
    console.log(property);
  }

  addTenant(property: any) {
    this.addTenantFlag = true
    this.selectedProperty = property;
  }

  onSubmit() {
    const formValue = {
      ...this.tenantForm.value,
      propertyId: this.selectedProperty?.id
    };

    console.log("Form value: ", formValue);

    this.leaseService.createFromScratch(formValue).subscribe({next: (value: any) => console.log(value)})
  }
}
