export enum PropertyType{
  Apartment,
  House,
  Commercial,
  Room
}

export const propertyTypeMap = new Map([
  [PropertyType.Apartment, 'Apartment'],
  [PropertyType.House, 'House'],
  [PropertyType.Commercial, 'Commercial'],
  [PropertyType.Room, 'Room']
]);
