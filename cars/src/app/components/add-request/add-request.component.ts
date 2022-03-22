import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { JoinManagmentService } from '../../services/join-managment.service';
import { MapComponent } from '../map/map.component';
import { Days } from '../../models/days.model';
import { JoinRequest } from '../../models/joinRequest.model';
import { RegularTravel } from '../../models/regularTravel.model';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ThemePalette } from '@angular/material/core';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.scss']
})
export class AddRequestComponent implements OnInit {

  private searchRequest: JoinRequest;

  days = new FormControl();
  JoinRequest: JoinRequest;
  travelR: RegularTravel[] = [];
  displayedColumnsR: string[];
  index: number;
  //sppiner
  toLoaded: Boolean;
  mode: ProgressSpinnerMode;
  color: ThemePalette = 'accent';

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

  constructor(private http: JoinManagmentService,
    public dialogRef: MatDialogRef<AddRequestComponent>,
    private httpJoin: JoinManagmentService,
    public dialog: MatDialog,
    public sppinerDialog: MatDialog) { }

  ngOnInit(): void {
    this.toLoaded = false;
    this.mode = 'indeterminate';
    this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day', 'join', 'map'];
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

  searchTravels(): void {
    this.toLoaded = true;
    this.searchRequest = {} as JoinRequest;
    this.searchRequest.source = this.sourceAddress.value;
    this.searchRequest.sourceRange = this.sourceRange.value / 1000;
    this.searchRequest.destination = this.destinationAddress.value;
    this.searchRequest.destinationsRange = this.destinationRange.value / 1000;
    this.searchRequest.timeEixt = this.timeExit.value;
    this.searchRequest.timeRange = this.exitTimeRange.value;
    this.searchRequest.dayList = this.days.value.toString();
    this.http.search(this.searchRequest).subscribe(res => {
      this.travelR = res;
      this.toLoaded = false;
    });
  }

  joinTravel(travel: any) {
    var request: JoinRequest = {} as JoinRequest;
    request.UserId = Number(localStorage.getItem('UserToken'));//יש לקבל את הזהות של הנוסע
    request.date = new Date();
    this.index = this.travelR.indexOf(travel);
    request.regularTravelId = travel.id;
    request.destination = this.searchRequest.destination;
    request.source = this.searchRequest.source;
    if (confirm("האם אתה בטוח מעונין להצטרף לנסיעה מס'" )) {
      this.toLoaded = true;
      this.httpJoin.joinRequest(request).subscribe(res => {
        console.log('res: ', res);
        this.toLoaded = false;
        this.onNoClick();
      });
    }
  }

  showMap(travel: any) {
    const dialogRef = this.dialog.open(MapComponent, {
      width: '1200px',
      data: travel
    });
  }
}
function mapComponent(mapComponent: any, arg1: { width: string; data: any; disableClose: true; }) {
  throw new Error('Function not implemented.');
}

