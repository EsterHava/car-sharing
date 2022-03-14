import { Component, OnInit, Input } from '@angular/core';
import { JoinRequest } from '../../models/joinRequest.model';
import { ActivatedRoute } from '@angular/router';
import { JoinManagmentService } from '../../services/join-managment.service';
import { UserManagmentServiceService } from '../../services/user-managment-service.service';
import { Message } from '../../models/message';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  requestsList: JoinRequest[];
  messagesList : Message[] = [];
  driverId: any;

  constructor(private route: ActivatedRoute,
    private http: JoinManagmentService,
    private httpUser: UserManagmentServiceService) { }

  ngOnInit(): void {
    this.getMessages();
    //this.getRequestsByDriverId();

  }


  getMessages(){
    const userId = localStorage.getItem('UserToken');
    this.httpUser.getMessages(userId ? userId:'').subscribe(messages => {
      console.log('messages :',messages);
      this.messagesList = messages;
  
  });
  }
 
//   getRequestsByDriverId() {
    
//      this.http.getRequestsByDriverId(this.driverId).subscribe(r => {this.requestsList = r,console.log(this.requestsList)});
    
//   }
// getUserNameById(id: number) {
//     return this.httpUser.getUserNameById(id.toString()).subscribe();
//   }

}
