import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from '../models/user.model';
import { UserManagmentServiceService } from '../user-managment-service.service';
import { FormControl, Validators, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Car } from '../models/car';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  user: User
  car:Car
  email = new FormControl('', [Validators.required, Validators.email]);
  firstName = new FormControl('', [Validators.required]);
  lastName = new FormControl('', [Validators.required]);
  tel = new FormControl('', [Validators.min(9), Validators.max(12)]);

  textError: string;
  x:any=2;
  constructor(private http: UserManagmentServiceService,private router: Router) {
    this.user = {} as User;
    this.car={} as Car
  }

  ngOnInit(): void { 
    
    if(localStorage.getItem('UserToken'))  {
      const userId=localStorage.getItem('UserToken');
      this.http.getUserByUserId(String(userId)).subscribe(res =>this.user=res)
   }
      }

 registerDetails (password: string) {
    if (this.checkPassword(password)) {
      this.http.register(this.user).subscribe(res =>{console.log(res)
        this.http.addCar(this.car).subscribe()
      if(Boolean(res)){
        
         this.router.navigateByUrl('privateArea/'+this.user.id);
      }
    else{
    }
    } ,
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
   
  checkPassword(password: string) {
    if (password.length != this.user.password.length) {
      this.textError = 'אימות הסיסמא אינו תקין.';
      return false;
    }
    else {
      for (let index = 0; index < password.length; index++) {
        if (password[index] != this.user.password[index]) {
          this.textError = 'אימות הסיסמא אינו תקין.';
          return false;
        }
      }
      return true;
    }
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'שדה חובה';
    }
    if (this.tel.hasError('min')) {
      return 'מספר לא תקין';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
  onSubmit(registerForm: NgForm) {
    const form = registerForm.value;
    this.user = form as User;
    console.log(this.user);
  }
}

