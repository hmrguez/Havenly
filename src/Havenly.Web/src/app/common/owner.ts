// public UserId UserId { get; set; }
// public User User { get; set; } = null!;
//
// public List<Property> Properties { get; set; } = [];

import {Property} from "./property";

export class Owner {
  constructor(public Id: string,
              public UserId: string,
              public Name: string,
              public Email: string,
              public ContactInfo: string,
              public Properties: Property[]) {
  }
}
