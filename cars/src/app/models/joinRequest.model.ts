import { Time } from "@angular/common";


export interface JoinRequest {
    id: number,
    UserId: number,
    date: Date,
    regularTravelId: number,
    temporaryTravelId: number,
    day:number,
    destination:string,
    source:string,
    timeEixt:Time,
    destinationsRange:number,
    sourceRange:number,
    timeRange:number,
    dayList:string    
}