import { Time } from '@angular/common';

export interface TemporaryTravel {
    id: number,
    driverId: number,
    destination: string,
    source: string,
    exitTime: Time,
    arriveTime: Time,
    date: Date
}


       