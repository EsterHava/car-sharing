import { Time } from '@angular/common';
import { RegularTravel } from './regularTravel.model';

export interface TravelerTraveling {
    id: number,
    travelerId: number,
    destination: string,
    source: string,
    exitTime: Time,
    arriveTime: Time,
    day: number,
    regularTravelingId:number,
    collectingPoint:string,
    destinationPoint:string,
    regularTraveling:RegularTravel

}