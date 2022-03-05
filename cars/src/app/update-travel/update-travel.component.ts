import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegularTravel } from '../models/regularTravel.model';
import { Days } from '../models/days.model';
import { TemporaryTravel } from '../models/temporaryTravel.model';
import { TravelManagementService } from '../travel-management.service';
import { DatePipe } from '@angular/common';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-update-travel',
  templateUrl: './update-travel.component.html',
  styleUrls: ['./update-travel.component.scss']
})

export class UpdateTravelComponent implements OnInit {

  travel: any;

  statusTravel: boolean;

  daysList: Days[] = [
    { key: 1, value: ' יום ראשון' },
    { key: 2, value: 'יום שני' },
    { key: 3, value: 'יום שלישי' },
    { key: 4, value: 'יום רביעי' },
    { key: 5, value: 'יום חמישי' },
    { key: 6, value: 'יום שישי' }];

  constructor(private route: ActivatedRoute,
    private http: TravelManagementService,
    private router: Router,
    public dialogRef: MatDialogRef<UpdateTravelComponent>,
    @Inject(MAT_DIALOG_DATA) public newTravel: any,
    private datepipe: DatePipe
  ) { }

  ngOnInit(): void {
    // this.travel = JSON.parse(JSON.stringify(this.route.snapshot.params));
    this.travel = this.newTravel;
    console.log("this travel   * " + this.travel)
    // this.travel=[...this.travel];
    if (this.travel.day) {
      this.statusTravel = true;
    }
    else {
      this.statusTravel = false;
      this.travel.date = this.datepipe.transform(this.travel.date, 'yyyy-MM-dd');
    }
    console.log(this.statusTravel);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  updateTravel() {
    if (this.statusTravel) {
      this.http.updateRegularTravel(this.travel).subscribe(t => {
        console.log(t);
        this.onNoClick();
      });
    }
    // else {
    //   this.http.updateTemporaryTravel(this.travel).subscribe(t => console.log(t));
    // }
    //this.router.navigateByUrl('');

  }
}
