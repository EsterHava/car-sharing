import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MatInputModule } from '@angular/material/input';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterContinueComponent } from './register-continue/register-continue.component';
import { AddTravelComponent } from './add-travel/add-travel.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { UpdateTravelComponent } from './update-travel/update-travel.component';
import { DatePipe } from '@angular/common';
import { PrivateAreaComponent } from './private-area/private-area.component';
import { TableForDriverComponent } from './table-for-driver/table-for-driver.component';
import { MessagesComponent } from './messages/messages.component'
import {MatDialogModule} from '@angular/material/dialog';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MainComponent } from './main/main.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import{ MatGridListModule } from '@angular/material/grid-list';
import { AboutComponent } from './about/about.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ForgotPasswordComponent,
    RegisterContinueComponent,
    AddTravelComponent,
    UpdateTravelComponent,
    PrivateAreaComponent,
    TableForDriverComponent,
    MessagesComponent,
    NavBarComponent,
    MainComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatTableModule,
    MatDialogModule,
    MatToolbarModule,
    MatGridListModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
