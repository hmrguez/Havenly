import {Component} from '@angular/core';
import {Property} from "../common/property";
import {propertyTypeMap} from "../common/propertyType";
import {PropertiesService} from "./properties.service";

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrl: './properties.component.scss'
})
export class PropertiesComponent {

  properties: Property[] = [];
  protected readonly propertyTypeMap = propertyTypeMap;

  constructor(private propertiesService: PropertiesService) {
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
}
