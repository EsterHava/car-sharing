import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { JoinManagmentService } from '../../services/join-managment.service';
import { MapComponent } from '../map/map.component';
import { Days } from '../../models/days.model';
import { JoinRequest } from '../../models/joinRequest.model';
import { RegularTravel } from '../../models/regularTravel.model';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.scss']
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
        
  travelR: RegularTravel[] = [];
  displayedColumnsR: string[];
  index: number;

    
  constructor(private http: JoinManagmentService,public dialogRef: MatDialogRef<AddRequestComponent>, private httpJoin: JoinManagmentService,
    public dialog: MatDialog) { }

  


  ngOnInit(): void {
    this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day','join','map'];
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  formatLabel(value: number) {    
    if (value >= 500) {    
      return value / 1000 + 'k';
    }
    return value;
  }

  searchTravels(): void{
    debugger
    this.searchRequest  = {} as JoinRequest;
    this.searchRequest.source = this.sourceAddress.value;
    this.searchRequest.sourceRange = this.sourceRange.value/1000;
    this.searchRequest.destinations = this.destinationAddress.value;
    this.searchRequest.destinationsRange = this.destinationRange.value/1000;
    this.searchRequest.timeEixt = this.timeExit.value;
    this.searchRequest.timeRange = this.exitTimeRange.value;
    this.searchRequest.dayList=this.days.value.toString();
    this.http.search(this.searchRequest).subscribe(res => {
      this.travelR=res;
    });

  }

  joinTravel(travel: any) {
    var request: JoinRequest = {} as JoinRequest;
    request.UserId = Number(localStorage.getItem('UserToken'));//יש לקבל את הזהות של הנוסע
    request.date = new Date();
    this.index = this.travelR.indexOf(travel);
    request.regularTravelId = travel.id;
    

    if (confirm("האם אתה בטוח מעונין להצטרף לנסיעה מס'- " + (this.index + 1))) {

      this.httpJoin.joinRequest(request).subscribe();
    }
  }

  showMap(travel: any) {
    const dialogRef = this.dialog.open(MapComponent, {
      width: '700px',
      data:travel 
    });
  }

   
}
function mapComponent(mapComponent: any, arg1: { width: string; data: any; disableClose: true; }) {
  throw new Error('Function not implemented.');
}

