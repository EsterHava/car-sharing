import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { JoinRequest } from './models/joinRequest.model';

@Injectable({
  providedIn: 'root'
})
export class JoinManagmentService {

  private url = "https://localhost:44391/api/JoinManagement";

  constructor(private http: HttpClient) { }

  joinRequest(request: JoinRequest) {
    console.log("ddfghjkl;");
    return this.http.post<boolean>(this.url + "/join", request);
  }

  getRequestsByDriverId(driverId: string) {
    const params = new HttpParams({
      fromObject: {
        driverId:driverId
      }
    });
    return this.http.get<any[]>(this.url + "/getRequests", {params:params});
  }

}
