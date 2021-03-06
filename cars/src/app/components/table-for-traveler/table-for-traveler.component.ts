import { Component, OnInit, Input } from '@angular/core';
import { RegularTravel } from '../../models/regularTravel.model';
import { Days } from '../../models/days.model';
import { ActivatedRoute, Router } from '@angular/router';
import { TravelManagementService } from '../../services/travel-management.service';
import { JoinManagmentService } from '../../services/join-managment.service';
import { JoinRequest } from '../../models/joinRequest.model';
import { DateAdapter } from '@angular/material/core';
import { AddTravelComponent } from '../add-travel/add-travel.component';
import { MatDialog } from '@angular/material/dialog';
import { UpdateTravelComponent } from '../update-travel/update-travel.component';
import { TravelerTraveling } from '../../models/travelerTraveling';
import { AddRequestComponent } from '../add-request/add-request.component';

@Component({
  selector: 'app-table-for-traveler',
  templateUrl: './table-for-traveler.component.html',
  styleUrls: ['./table-for-traveler.component.scss']
})
export class TableForTravelerComponent implements OnInit {

  //מערך עבור נסיעות קבועות של הנהג
  travelers: TravelerTraveling[] = [];
  displayedColumnsR: string[];
  //מערך של כל ימות השבוע
  daysList: Days[] = [
    { key: 1, value: 'יום ראשון' },
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
    this.getTravels();
    this.displayedColumnsR = ['num', 'source', 'destination', 'exitTime', 'arriveTime', 'day', 'delete'];
  }

  getTravels() {
    this.http.getTravelingForTraveller().subscribe(t => {
      console.log('travelers: ', t);
      this.travelers = t;
    });
  }

  joinTravel(travel: any) {
    var request: JoinRequest = {} as JoinRequest;
    request.UserId = 1;//יש לקבל את הזהות של הנוסע
    request.date = new Date();
    console.log(request.date);
    if (travel.date == null) {
      this.index = this.travelers.indexOf(travel);
      request.regularTravelId = travel.id;
    }
    else {
      request.temporaryTravelId = travel.id;
    }
    if (confirm("האם אתה בטוח מעונין להצטרף לנסיעה מס'- " + (this.index + 1))) {
      this.httpJoin.joinRequest(request).subscribe(t => console.log(t));
    }
  }

  deleteTravel(travelerInTravel: TravelerTraveling) {
    if (confirm("האם אתה בטוח מעונין לבטל את הצטרפותך לנסיעה זו- " + (this.index + 1))) {
      this.http.deleteTravelerInTravel(travelerInTravel).subscribe(t => {
        console.log(t);
        this.getTravels();
      });
    }
  }

  openAddTravelDialog() {
    const dialogRef = this.dialog.open(AddRequestComponent, {
      width: '900px'
    });
  }
}

