import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { JoinRequest } from '../models/joinRequest.model';
import { RegularTravel } from '../models/regularTravel.model';

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
        driverId: driverId
      }
    });
    return this.http.get<JoinRequest[]>(this.url + "/getRequests", { params: params });
  }

  search(request: JoinRequest) {
    return this.http.post<any[]>(`${this.url}/search`, request);
  }

  getTravelByRequestId(reqId: string) {
    const params = new HttpParams({
      fromObject: {
        reqId: reqId
      }
    });
    return this.http.get<any>(this.url + '/getTravel', { params: params });
  }

  approveRequest(reqId:string, isApprove:string){
    const params = new HttpParams({
      fromObject: {
        reqId: reqId,
        isApprove:isApprove
      }
    });

    return this.http.get<any>(this.url + '/approveRequest',{params:params});
    // return this.http.get<boolean>(this.url + `/approveRequest/${reqId}/${isApprove}`);
  }
}
