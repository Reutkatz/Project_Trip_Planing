
export enum DayOfWeek
{
    Sunday, Monday, Tuesday, Wednsday, Thursday, Friday, Suterday
}
export class OpenHour
{
    constructor(
    public id :number=0,
    public day : DayOfWeek,
    public openingTime:string,
    public closingTime :string,
    public PlaceId: number){}
}

