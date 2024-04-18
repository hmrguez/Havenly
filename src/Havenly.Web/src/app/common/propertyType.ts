export enum PropertyType{
  Apartment = "APARTMENT",
  House = "HOUSE",
  Commercial = "COMMERCIAL",
  Room = "ROOM"
}

export const propertyTypeMap = new Map([
  [PropertyType.Apartment, 'Apartment'],
  [PropertyType.House, 'House'],
  [PropertyType.Commercial, 'Commercial'],
  [PropertyType.Room, 'Room']
]);
