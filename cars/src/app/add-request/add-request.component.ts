import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { JoinManagmentService } from '../join-managment.service';
import { Days } from '../models/days.model';
import { JoinRequest } from '../models/joinRequest.model';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.sass']
})
export class AddRequestComponent implements OnInit {
  
  private searchRequest: JoinRequest;

  days = new FormControl();
  JoinRequest : JoinRequest;
  daysList: Days[] = [
    { key: 1, value: ' יום ראשון' },
    { key: 2, value: 'יום שני' },
    { key: 3, value: 'יום שלישי' },
    { key: 4, value: 'יום רביעי' },
    { key: 5, value: 'יום חמישי' },
    { key: 6, value: 'יום שישי' }];

    exitTimeRange = new FormControl('', [
      Validators.required,
    ]);
    timeExit = new FormControl('', [
      Validators.required,
    ]);
    destinationRange = new FormControl('', [
      Validators.required,
    ]);
    destinationAddress = new FormControl('', [
      Validators.required,
    ]);
    sourceRange = new FormControl('', [
      Validators.required,
    ]);
    sourceAddress = new FormControl('', [
      Validators.required,
    ]);
    
    
    
    
  constructor(private http: JoinManagmentService,public dialogRef: MatDialogRef<AddRequestComponent>) { }


  ngOnInit(): void {

  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  searchTravels(): void{
    debugger
    this.searchRequest  = {} as JoinRequest;
    this.searchRequest.source = this.sourceAddress.value;
    this.searchRequest.sourceRange = this.sourceRange.value;
    this.searchRequest.destinations = this.destinationAddress.value;
    this.searchRequest.destinationsRange = this.destinationRange.value;
    this.searchRequest.timeEixt = this.timeExit.value;
    this.searchRequest.timeRange = this.exitTimeRange.value;
    this.http.search(this.searchRequest).subscribe(u => {
    
       });

  }

}
