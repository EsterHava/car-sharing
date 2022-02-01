import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { AddTravelComponent } from './add-travel/add-travel.component';
import { UpdateTravelComponent } from './update-travel/update-travel.component';
import { PrivateAreaComponent } from './private-area/private-area.component';
import { TableForDriverComponent } from './table-for-driver/table-for-driver.component';
import { MessagesComponent } from './messages/messages.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: 'addTravel/:driverId', component: AddTravelComponent },
  //{ path: 'travelForDriver/:driverId', component: TravelForDriverComponent },
  { path: 'updateTravel', component: UpdateTravelComponent },
  { path: 'privateArea/:userId', component: PrivateAreaComponent },
  { path: 'tableForDriver', component: TableForDriverComponent },
  { path: 'messages/:userId', component: MessagesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
