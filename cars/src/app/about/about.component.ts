import { Component, OnInit } from '@angular/core';
import { UserManagmentServiceService } from '../user-managment-service.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.sass']
})
export class AboutComponent implements OnInit {

  constructor(private http: UserManagmentServiceService) { }

  userName: string;
  wishes: string;

  ngOnInit(): void {
    this.getWish();
    this.getUserNameById(String(localStorage.getItem('UserToken')));
  }

  getUserNameById(id: string) {
    return this.http.getUserNameById(id).subscribe(rst => {
      console.log('userName', rst),
      this.userName = rst.toString()
    });
  }

  getWish() {
    
   
  var today = new Date()
    var curHr = today.getHours()
debugger
    if (curHr >1&& curHr<12) {
      this.wishes = 'בוקר טוב';
    } 
    else if (curHr >=12&& curHr < 18) {
      this.wishes = 'אחר הצהרים טובים';
    }
     else if (curHr >=18&&curHr < 24) {
      this.wishes = 'ערב טוב';
    }
    else {
      this.wishes = "לילה טוב"
    }
  }

}
