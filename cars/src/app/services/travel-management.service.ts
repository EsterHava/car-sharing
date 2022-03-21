import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RegularTravel } from '../models/regularTravel.model';
import { TravelerTraveling } from '../models/travelerTraveling';

@Injectable({
  providedIn: 'root'
})
export class TravelManagementService {

  private url = "https://localhost:44391/api/TravelManagement";

  constructor(private http: HttpClient) { }

  getRegularTravel() {
    return this.http.get<RegularTravel[]>(this.url + "/GetRegularTravel");
  }

  getTravelingForTraveller() {
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

  addRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/AddRegularTravel", travel);
  }

  deleteRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/DeleteRegularTravel", travel);
  }

  updateRegularTravel(travel: RegularTravel) {
    return this.http.post<boolean>(this.url + "/UpdateRegularTravel", travel);
  }

  deleteTravelerInTravel(tr:TravelerTraveling){
    return this.http.post<boolean>(this.url+'/DeleteTravellerInTravel',tr)
  }
}
