import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { UserManagmentServiceService } from '../../services/user-managment-service.service';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  textError: string;
  email = new FormControl('', [Validators.required, Validators.email]);

  constructor(private http: UserManagmentServiceService, private router: Router) { }

  ngOnInit(): void {
  }

  changePassword(userName: string, password: string, verifyPassword: string) {
    if (password == verifyPassword) {
      this.textError = "";
      this.http.getUserByUserName(userName).subscribe(u => {
        console.log(u);
        if (u == null) {
          this.textError = "!!! שם המשתמש אינו תקין";
        }
        else {
          this.textError = "";
          u.password = password;
          this.http.updateUser(u).subscribe(user => {
            if (user != null) {
              //Kהוסיף ההראה שהכל הצליח
              this.router.navigateByUrl('/login');
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


  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
}
