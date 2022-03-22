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
  messagesList: Message[] = [];
  msgReq = new Map<Number, String>();
  driverId: any;

  constructor(private route: ActivatedRoute,
    private http: JoinManagmentService,
    private httpUser: UserManagmentServiceService) { }

  ngOnInit(): void {
    this.driverId = localStorage.getItem('UserToken');
    console.log('driverId: ', this.driverId);
    this.getMessages();
    this.getRequest();
  }

  getMessages() {
    const userId = localStorage.getItem('UserToken');
    this.httpUser.getMessages(userId ? userId : '').subscribe(messages => {
      console.log('messages :', messages);
      this.messagesList = messages;

    });
  }

  isReadMsg(msgSelected: any) {
    console.log('msg:', msgSelected);
  }

  getRequest() {
    this.http.getRequestsByDriverId(this.driverId).subscribe(res => {
      this.requestsList = res;
      for (let req of this.requestsList) {
        console.log('item: ', req);
        this.http.getTravelByRequestId(req.id.toString())
          .subscribe(t => {
            console.log('travel:', t);
            const msgReq = `?  נוסע מעונין להצטרף לנסיעה ביום ${t.day} מ- ${t.source} ל- ${t.destination} , האם הנך מאשר `;
            this.msgReq.set(req.id, msgReq);

          });
      }
    });
    console.log('msgReq: ', this.msgReq);
  }

  approveRequest(reqId: Number, isApprove: string) {
    this.http.approveRequest(reqId.toString(),isApprove).subscribe(res => {
      console.log('response: ', res);
    })
  }
}
