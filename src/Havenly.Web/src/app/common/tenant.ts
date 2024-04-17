import {Gender} from "./gender";

export class Tenant {
  constructor(
    public Id: string,
    public UserId: string,
    public Name: string,
    public Email: string,
    public ContactInfo: string,
    public Gender: Gender,
    public AverageSalary: number,
    public Age: number) {
  }
}
