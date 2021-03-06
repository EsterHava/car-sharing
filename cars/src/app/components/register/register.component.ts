import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from '../../models/user.model';
import { UserManagmentServiceService } from '../../services/user-managment-service.service';
import { FormControl, Validators, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Car } from '../../models/car';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  user: User
  car: Car
  email = new FormControl('', [Validators.required, Validators.email]);
  firstName = new FormControl('', [Validators.required]);
  lastName = new FormControl('', [Validators.required]);
  tel = new FormControl('', [Validators.min(9), Validators.max(12)]);
  isNew: number;
  confirmPassword:string;

  textError: string;
  x: any = 2;
  constructor(private http: UserManagmentServiceService, private router: Router) {
    this.user = {} as User;
    this.car = {} as Car
  }

  ngOnInit(): void {

    if (localStorage.getItem('UserToken')) {
      this.isNew = 0;
      const userId = localStorage.getItem('UserToken');
      this.http.getUserByUserId(String(userId)).subscribe(res => {
        this.user = res;
        console.log('user: ', this.user);
      });
    }
    else {
      this.isNew = 1;
    }
  }

  btnOkNewUser() {

    if (this.checkPassword(this.confirmPassword)) {
      this.http.register(this.user).subscribe(res => {
        console.log(res)
        this.http.addCar(this.car).subscribe()
        if (Boolean(res)) {
          this.router.navigate(['/login']);
          //localStorage.setItem('UserToken', this.user.id.toString());
        }
      },
        (err) => {
          console.log(err);
          this.textError = err.message;
        });
      // this.http.addCar(this.car).subscribe(res =>{console.log(res)})
    }
  }

  addCar() {
    this.http.addCar(this.car).subscribe();
  }
  btnOk() {
    this.http.updateUser(this.user).subscribe(res => console.log('res: ', res));
  }

  checkPassword(password: string) {
    if (password.length != this.user.password.length) {
      this.textError = '?????????? ???????????? ???????? ????????.';
      return false;
    }
    else {
      for (let index = 0; index < password.length; index++) {
        if (password[index] != this.user.password[index]) {
          this.textError = '?????????? ???????????? ???????? ????????.';
          return false;
        }
      }
      return true;
    }
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return '?????? ????????';
    }
    if (this.tel.hasError('min')) {
      return '???????? ???? ????????';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  onSubmit(registerForm: NgForm) {
    const form = registerForm.value;
    this.user = form as User;
    console.log(this.user);
  }
}

