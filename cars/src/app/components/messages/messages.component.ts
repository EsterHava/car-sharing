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
    //this.getRequestsByDriverId();

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
            const msgReq = `? האם הנך מאשר, ${t.destination}-ל ${t.source}-מ ${t.day} נוסע מעונין להצטרף לנסיעה ביום `;
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



  //   getRequestsByDriverId() {

  //      this.http.getRequestsByDriverId(this.driverId).subscribe(r => {this.requestsList = r,console.log(this.requestsList)});

  //   }
  // getUserNameById(id: number) {
  //     return this.httpUser.getUserNameById(id.toString()).subscribe();
  //   }

}
