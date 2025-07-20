import { IsraelRegion } from "./trip";

export class Category {
  constructor(
    public id: number = 0,
    public name?: string,
    public address?: string,
    public rating?: number,
    public reviewsCount?: number,
    public website?: string,
    public price?: number,
    public region?:IsraelRegion,
  ) {}
}