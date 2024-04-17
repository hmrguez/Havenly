import {PropertyType} from "./propertyType";
import {Amenity} from "./amenity";
import {Owner} from "./owner";

export class Property {
  constructor(public Id: string,
              public Type: PropertyType,
              public Street: string,
              public City: string,
              public ZipCode: string,
              public Country: string,
              public Bedrooms: number,
              public Bathrooms: number,
              public SquareFootage: number,
              public Price: number,
              public RentalPrice: number,
              public OwnerId: string,
              public Owner: Owner | null,
              public Amenities: Amenity[]) {
  }
}
