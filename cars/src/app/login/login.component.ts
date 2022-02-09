import { Component, OnInit } from '@angular/core';
import { UserManagmentServiceService } from '../user-managment-service.service';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  
  user: User;
  textErorr: string;

  constructor(private http: UserManagmentServiceService,private router: Router){ }
   

  ngOnInit(): void {
   
  }

  login(userName: string, password: string) {
    debugger
    this.user = {} as User;
    this.user.userName = userName;
    this.user.password = password;
    this.http.login(this.user).subscribe(u => { console.log("***"), this.user = u , this.checkNull() });
  }
  checkNull() {
    debugger
    if (this.user != null) {
      this.textErorr = "";
      console.log(this.textErorr);
      this.router.navigateByUrl('main');
      localStorage.setItem('UserToken',this.user.id.toString());
      localStorage.setItem('Profil',this.user.isHasCar.toString());


      //console.log(this.user);
    }
    else {
      this.textErorr = "שם המשתמש או הסיסמא אינם תקינים";
      console.log(this.textErorr);
    }
  }
}
