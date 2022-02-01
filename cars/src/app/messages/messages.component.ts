import { Component, OnInit, Input } from '@angular/core';
import { JoinRequest } from '../models/joinRequest.model';
import { ActivatedRoute } from '@angular/router';
import { JoinManagmentService } from '../join-managment.service';
import { UserManagmentServiceService } from '../user-managment-service.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  requestsList: JoinRequest[];

  driverId: any;

  constructor(private route: ActivatedRoute,
    private http: JoinManagmentService,
    private httpUser: UserManagmentServiceService) { }

  ngOnInit(): void {
    
    //this.getRequestsByDriverId();

  }
 
//   getRequestsByDriverId() {
    
//      this.http.getRequestsByDriverId(this.driverId).subscribe(r => {this.requestsList = r,console.log(this.requestsList)});
    
//   }
// getUserNameById(id: number) {
//     return this.httpUser.getUserNameById(id.toString()).subscribe();
//   }

}
