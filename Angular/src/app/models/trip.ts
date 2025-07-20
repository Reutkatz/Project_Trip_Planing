import { Time } from "@angular/common";

export class Trip {
    constructor(
        public id?: number,
        public date?: Date,
        public title?: String,
        public budget?: number,
        public region?: IsraelRegion,
        public startTime?: Time,
        public endTime?: Time,     
        public numOfAttractions?: number,
        public numOfTrails?: number,
        public numOfStoppingPlaces?: number,
     ) { }
}

    export enum IsraelRegion
    {
        North,        
        LowerGalilee,  
        Haifa,         
        Sharon,        
        GushDan,       
        Jerusalem,     
        Negev,         
        Eilat         
    }
