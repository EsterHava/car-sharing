import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RegularTravel } from './models/regularTravel.model';
import { TemporaryTravel } from './models/temporaryTravel.model';
import { TravelerTraveling } from './models/travelerTraveling';

@Injectable({
  providedIn: 'root'
})
export class TravelManagementService {

  private url = "https://localhost:44391/api/TravelManagement";

  constructor(private http: HttpClient) { }

  getRegularTravel() {
    return this.http.get<RegularTravel[]>(this.url + "/GetRegularTravel");
  }

  getTemporaryTravel() {
    return this.http.get<TemporaryTravel[]>(this.url + "/GetTemporaryTravel");
  }

  getTravelingForTraveller() {
    debugger
    const userId=localStorage.getItem('UserToken');
 
    return this.http.get<TravelerTraveling[]>(`${this.url}/GetTravelerTravelings/${localStorage.getItem('UserToken')}`);
  }

  getRegularTravelByDriver(id: string) {
    const params = new HttpParams({
      fromObject: {
        driverId: id
      }
    });
    return this.http.get<any[]>(this.url + "/GetRegularTravelByDriver", { params: params });
  }
  getTemporaryTravelByDriver(id: string) {
    const params = new HttpParams({
      fromObject: {
        driverId: id
      }
    });
    return this.http.get<any[]>(this.url + "/GetTemporaryTravelByDriver", { params: params });
  }
  addRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/AddRegularTravel", travel);
  }
  addTemporaryTravel(travel: TemporaryTravel) {
    return this.http.post<boolean>(this.url + "/AddTemporaryTravel", travel);
  }
  //?????
  deleteRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/DeleteRegularTravel", travel);
  }
  //?????
  deleteTemporaryTravel(travel: TemporaryTravel) {
    return this.http.post<boolean>(this.url + "/DeleteTemporaryTravel", travel,);
  }
  updateRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/UpdateRegularTravel", travel);
  }
  updateTemporaryTravel(travel: TemporaryTravel) {
    return this.http.post<boolean>(this.url + "/UpdateTemporaryTravel", travel);;
  }
}
