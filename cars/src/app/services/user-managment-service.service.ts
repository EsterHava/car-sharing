import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../models/user.model';
import { Car } from '../models/car';
import { Message } from '../models/message';


@Injectable({
  providedIn: 'root'
})
export class UserManagmentServiceService {

  private url = "https://localhost:44391/api/UserManagement";

  constructor(private http: HttpClient) { }

  getUserByUserName(userName: string) {
    const params = new HttpParams({
      fromObject: {
        userName: userName,
      }
    });
    return this.http.get<User>(this.url + "/GetUserByUserName", { params: params })
  }

  getUserByUserId(id: string) {
    const params = new HttpParams({
      fromObject: {
        id: id,
      }
    });
    return this.http.get<User>(this.url + "/GetUserByUserId", { params: params })
  }

  getUserNameById(id: string) {
    
    
    const params = new HttpParams({
      fromObject: {
        id: id,
      }
    });
     return this.http.get<User>(this.url + "/GetUserNameById", { params: params });
    //return this.http.get(`${this.url}/GetUserNameById?id=${id}`);

  }


  login(user: User) {
    return this.http.post<User>(this.url + "/Login", user);
    
  }

  register(user: User) {
    return this.http.post<boolean>(this.url + "/Register", user);
  }

  updateUser(user: User) {
    return this.http.post<User>(this.url + "/UpdateUser", user);
  }

  addCar(car: Car) {
    return this.http.post<boolean>(this.url + "/AddCar", car);
  }

  getMessages(id:string){
    const params = new HttpParams({
      fromObject: {
        userId: id
      }
    });
    return this.http.get<Message []>(this.url+"/GetMessages", { params: params });
  }

}
