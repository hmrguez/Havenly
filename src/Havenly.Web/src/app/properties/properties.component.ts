import { Component } from '@angular/core';
import {Property} from "../common/property";
import {propertyTypeMap} from "../common/propertyType";

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrl: './properties.component.scss'
})
export class PropertiesComponent {
  properties: Property[] = [
    new Property('1', 0, '123 Main St', 'Anytown', '12345', 'USA', 2, 1, 1000, 100000, 1000, '1', null, []),
    new Property('2', 1, '456 Elm St', 'Anytown', '12345', 'USA', 3, 2, 1500, 150000, 1500, '2', null, []),
    new Property('3', 2, '789 Oak St', 'Anytown', '12345', 'USA', 4, 3, 2000, 200000, 2000, '3', null, []),
    new Property('4', 3, '101 Pine St', 'Anytown', '12345', 'USA', 1, 1, 500, 50000, 500, '4', null, []),
  ];

  showProperty(property: any) {
    console.log(property);
  }

  protected readonly propertyTypeMap = propertyTypeMap;
}
