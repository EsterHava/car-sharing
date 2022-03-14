import { Component, OnInit, Input } from '@angular/core';
import { User } from '../../models/user.model';
import { UserManagmentServiceService } from '../../services/user-managment-service.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-register-continue',
  templateUrl: './register-continue.component.html',
  styleUrls: ['./register-continue.component.sass']
})
export class RegisterContinueComponent implements OnInit {
  textError: string;
  firstName=this.rout.snapshot.paramMap.get('firstName');

  constructor(private http: UserManagmentServiceService, private router: Router, private rout: ActivatedRoute) { }

  ngOnInit(): void {
  }
  changePassword(userName: string, password: string, verifyPassword: string) {
    if (password == verifyPassword) {
      this.textError = "";
      this.http.getUserByUserName(userName).subscribe(u => {
        if (u == null) {
          this.textError = "!!! שם המשתמש אינו תקין";
        }
        else {
          this.textError = "";
          (u as User).password = password;
          this.http.updateUser(u as User).subscribe(user => {
            if (user != null) {
              //Kהוסיף ההראה שהכל הצליח
              this.router.navigate(['/login']);
            }
            else {
              this.textError = " !!!!! ארע שגיאה ,נסה שוב ";
            }
          });
        }
      });
    }
    else {
      this.textError = "!!! אימות הסיסמא שגויה";
    }
  }

}
