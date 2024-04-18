export class Lease {
  constructor(
    public id: string,
    public rent: number,
    public startDate: Date,
    public endDate: Date,
    public deposit: number,
    public propertyId: string,
    public tenantId: string) {
  }
}
