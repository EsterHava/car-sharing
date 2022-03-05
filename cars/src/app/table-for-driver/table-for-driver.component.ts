import { Component, OnInit, Input } from '@angular/core';
import { RegularTravel } from '../models/regularTravel.model';
import { TemporaryTravel } from '../models/temporaryTravel.model';
import { Days } from '../models/days.model';
import { ActivatedRoute, Router } from '@angular/router';
import { TravelManagementService } from '../travel-management.service';
import { JoinManagmentService } from '../join-managment.service';
import { JoinRequest } from '../models/joinRequest.model';
import { DateAdapter } from '@angular/material/core';
import { AddTravelComponent } from '../add-travel/add-travel.component';
import { MatDialog } from '@angular/material/dialog';
import { UpdateTravelComponent } from '../update-travel/update-travel.component';

@Component({
  selector: 'app-table-for-driver',
  templateUrl: './table-for-driver.component.html',
  styleUrls: ['./table-for-driver.component.scss']
})

export class TableForDriverComponent implements OnInit {

  //@Input() status: string;
  @Input() status: string;

  //מערך עבור נסיעות קבועות של הנהג
  travelR: RegularTravel[] = [];

  displayedColumnsR: string[];

  //מערך עבור נסיעות חד פעמיות של הנהג
  // travelT: TemporaryTravel[] = [];

  // displayedColumnsT: string[];

  //מערך של כל ימות השבוע
  daysList: Days[] = [
    { key: 1, value: ' יום ראשון' },
    { key: 2, value: 'יום שני' },
    { key: 3, value: 'יום שלישי' },
    { key: 4, value: 'יום רביעי' },
    { key: 5, value: 'יום חמישי' },
    { key: 6, value: 'יום שישי' }
  ];

  @Input() driverId: any;

  index: number;

  constructor(private http: TravelManagementService,
    private route: ActivatedRoute,
    private router: Router,
    private httpJoin: JoinManagmentService,
    public dialog: MatDialog) {

  }


  ngOnInit(): void {
    // if (this.status == 'edit') {
    //   this.getRegularTravelByDriver();
    //   this.getTemporaryTravelByDriver();
    //   this.displayedColumnsT = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'date', 'delete', 'update'];
    //   this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day', 'delete', 'update'];
    // }
    // else {
    //   this.getTravel();
    //   this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day', 'join'];
    //   this.displayedColumnsT = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'date', 'join'];

    // }
    this.getRegularTravelByDriver();
    this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day', 'delete', 'update'];

  }

  getRegularTravelByDriver() {
    // const id = this.route.snapshot.paramMap.get('driverId');
    this.driverId = localStorage.getItem('UserToken');
    return this.http.getRegularTravelByDriver(this.driverId).subscribe(t => { console.log(t), this.travelR = t });
  }

  //נסיעות חד פעמיות של הנהג
  // getTemporaryTravelByDriver() {
  //   // const id = this.route.snapshot.paramMap.get('driverId');
  //   console.log(this.driverId);
  //   return this.http.getTemporaryTravelByDriver(this.driverId).subscribe(t => { console.log(t), this.travelT = t });
  // }

  getTravel() {
    // this.http.getTemporaryTravel().subscribe(t => this.travelT = t);
    this.http.getRegularTravel().subscribe(t => this.travelR = t);
    // console.log(this.travelT);
  }

  joinTravel(travel: any) {
    var request: JoinRequest = {} as JoinRequest;
    request.UserId = 1;//יש לקבל את הזהות של הנוסע
    request.date = new Date();
    console.log(request.date);
    if (travel.date == null) {
      this.index = this.travelR.indexOf(travel);
      request.regularTravelId = travel.id;
    }
    else {
      // this.index = this.travelT.indexOf(travel);
      request.temporaryTravelId = travel.id;
    }

    if (confirm("האם אתה בטוח מעונין להצטרף לנסיעה מס'- " + (this.index + 1))) {

      this.httpJoin.joinRequest(request).subscribe(t => console.log(t));
    }
  }


  deleteRegularTravel(travel: RegularTravel) {

    if (confirm("האם אתה בטוח מעונין למחוק נסיעה מס'-  " + (this.travelR.indexOf(travel) + 1))) {

      this.http.deleteRegularTravel(travel).subscribe(t => { console.log(t), this.getRegularTravelByDriver() });
    }
  }

  // deleteTemporaryTravel(travel: TemporaryTravel) {

  //   if (confirm("האם אתה בטוח מעונין למחוק נסיעה מס'-  " + (this.travelT.indexOf(travel) + 1))) {

  //     this.http.deleteTemporaryTravel(travel).subscribe(t => { console.log(t), this.getTemporaryTravelByDriver() });
  //   }
  // }

  updateRegularTravel(travel: RegularTravel) {
    if (confirm("האם אתה בטוח מעונין לעדכן נסיעה מס'- " + (this.travelR.indexOf(travel) + 1))) {

      this.router.navigate(['/updateTravel', travel]);
    }
  }

  // updateTemporaryTravel(travel: TemporaryTravel) {
  //   if (confirm("האם אתה בטוח מעונין לעדכן נסיעה מס'-  " + (this.travelT.indexOf(travel) + 1))) {

  //     this.router.navigate(['/updateTravel', travel]);
  //   }
  // }

  openAddTravelDialog() {
    const dialogRef = this.dialog.open(AddTravelComponent, {
      width: '550px',
      data: this.driverId,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.getRegularTravelByDriver();
    });
  }

  openUpdateRegularTravel(travel: RegularTravel) {
    console.log("travel rrr   " + travel)
    const dialogRef = this.dialog.open(UpdateTravelComponent, {
      width: '550px',
      data: travel,
      disableClose: true
    });
  }

}
