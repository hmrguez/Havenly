import {PropertyType} from "./propertyType";
import {Amenity} from "./amenity";
import {Owner} from "./owner";

export class Property {
  constructor(public id: string,
              public type: PropertyType,
              public street: string,
              public city: string,
              public zipCode: string,
              public country: string,
              public bedrooms: number,
              public bathrooms: number,
              public squareFootage: number,
              public price: number,
              public rentalPrice: number,
              public ownerId: string,
              public owner: Owner | null,
              public amenities: Amenity[]) {
  }
}
