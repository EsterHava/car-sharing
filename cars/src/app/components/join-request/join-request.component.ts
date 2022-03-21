import { Component, OnInit } from '@angular/core';
import { JoinManagmentService } from '../../services/join-managment.service';
import { JoinRequest } from '../../models/joinRequest.model';
import { TravelManagementService } from '../../services/travel-management.service';
import { UserManagmentServiceService } from '../../services/user-managment-service.service';

@Component({
  selector: 'app-join-request',
  templateUrl: './join-request.component.html',
  styleUrls: ['./join-request.component.sass']
})
export class JoinRequestComponent implements OnInit {

  constructor(private http: JoinManagmentService,
    private travelHttp: TravelManagementService,
    private userHttp: UserManagmentServiceService) { }

  requestsList: JoinRequest[];

  ngOnInit(): void {
  }

  getRequests() {
    this.http.getRequestsByDriverId(String(localStorage.getItem('UserToken'))).subscribe(res => this.requestsList = res);
  }

  getUserNameById(id: string) {
    //var user = User{};
    //this.userHttp.getUserByUserId(id).subscribe(res=> {user = res} );
    //return user.userName;
  }

}
