import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from './models/user.model';
import { Car } from './models/car';


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

  getUserNameById(id: string) {
    const params = new HttpParams({
      fromObject: {
        useId: id
      }
    });
    return this.http.get<string>(this.url + "/GetUserNameById", { params: params });
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
}
