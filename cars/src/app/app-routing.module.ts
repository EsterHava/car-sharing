import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { AddTravelComponent } from './components/add-travel/add-travel.component';
import { UpdateTravelComponent } from './components/update-travel/update-travel.component';
import { TableForDriverComponent } from './components/table-for-driver/table-for-driver.component';
import { MessagesComponent } from './components/messages/messages.component';
import { MainComponent } from './components/main/main.component';
import { AuthGuard } from './AuthGuard';
import { AboutComponent } from './components/about/about.component';
import { TableForTravelerComponent } from './components/table-for-traveler/table-for-traveler.component';


const routes: Routes = [{ path: 'login', component: LoginComponent },
{ path: '', component: LoginComponent },
{ path: 'register', component: RegisterComponent },
{ path: 'forgotPassword', component: ForgotPasswordComponent },
{
  path: 'main', component: MainComponent,
  children: [
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent },
    { path: '', component: AboutComponent },
    { path: 'about', component: AboutComponent },
    { path: 'addTravel/:driverId', component: AddTravelComponent },
    { path: 'tableForTraveller', component: TableForTravelerComponent },
    { path: 'updateTravel', component: UpdateTravelComponent },
    { path: 'tableForDriver', component: TableForDriverComponent },
    { path: 'messages', component: MessagesComponent },
    { path: 'register', component: RegisterComponent }
  ], canActivate: [AuthGuard]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
