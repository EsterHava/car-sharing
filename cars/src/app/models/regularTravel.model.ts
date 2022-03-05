import { Time } from '@angular/common';

export interface RegularTravel {
    id: number,
    driverId: number,
    destination: string,
    source: string,
    exitTime: Time,
    arriveTime: Time,
    day: number,
    latSourceRequest:number,
    longSourceRequest:number,
    latDestinationRequest:number,
    longDestinationRequest:number,
    latSourcr:number,
    longSource:number,
    latDestination:number,
    longDestination:number
}