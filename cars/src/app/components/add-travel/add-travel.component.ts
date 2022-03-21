import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { RegularTravel } from '../../models/regularTravel.model';
import { TravelManagementService } from '../../services/travel-management.service';
import { Days } from '../../models/days.model';
import { ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from '../../models/user.model';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ThemePalette } from '@angular/material/core';


@Component({
  selector: 'app-add-travel',
  templateUrl: './add-travel.component.html',
  styleUrls: ['./add-travel.component.scss']
})

export class AddTravelComponent implements OnInit {

  // הוספת נסיעה קבועה
  regularTravel: RegularTravel;

  //סוג הנסיעה
  statusTravel: any;

  //ימים עבור נסיעות קבועות
  days = new FormControl();

  //sppiner
  toLoaded:Boolean;
  mode: ProgressSpinnerMode;
  color: ThemePalette = 'accent';

  daysList: Days[] = [
    { key: 1, value: ' יום ראשון' },
    { key: 2, value: 'יום שני' },
    { key: 3, value: 'יום שלישי' },
    { key: 4, value: 'יום רביעי' },
    { key: 5, value: 'יום חמישי' },
    { key: 6, value: 'יום שישי' }];
  //עבור הנהג id
  driverId: any;

  constructor(
    private http: TravelManagementService,
    private route: ActivatedRoute,
    private sppinerDialog: MatDialog,
    public dialogRef: MatDialogRef<AddTravelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number) {
    this.statusTravel = true;
  }

  ngOnInit(): void {
    this.mode = 'indeterminate';
    //this.id = this.route.snapshot.paramMap.get('driverId');
    this.driverId = this.data;
    console.log("id    " + this.data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  addTravel(source: string, destination: string, exitTime: any, arriveTime: any, numSeats: any) {
    if (confirm("האם אתה בטוח מעונין להוסיף נסיעה זו? ")) {
      this.toLoaded = true;
      console.log(this.days.value);
      if (this.statusTravel) {
        this.regularTravel = {} as RegularTravel;
        this.regularTravel.source = source;
        this.regularTravel.destination = destination;
        this.regularTravel.exitTime = exitTime;
        this.regularTravel.arriveTime = arriveTime;
        this.regularTravel.driverId = this.driverId;
        this.regularTravel.availableSeats = numSeats;
        for (let index = 0; index < this.days.value.length; index++) {
          this.regularTravel.day = this.days.value[index];
          this.http.addRegularTravel(this.regularTravel).subscribe(t => {
            console.log(t);
            this.toLoaded = false;
            this.onNoClick();
          });
        }
      }
      // else {
      //   this.temporaryTravel = {} as TemporaryTravel;
      //   this.temporaryTravel.source = source;
      //   this.temporaryTravel.destination = destination;
      //   this.temporaryTravel.exitTime = exitTime;
      //   this.temporaryTravel.arriveTime = arriveTime;
      //   this.temporaryTravel.driverId = this.id;
      //   this.temporaryTravel.date = this.dateForTemporaryTravel;
      //   this.http.addTemporaryTravel(this.temporaryTravel).subscribe(t => console.log(t));
      // }

    }
  }

  // openSppiner() {
  //   const dialogRef = this.sppinerDialog.open(SppinerComponent, {
  //     width: '550px',
  //     disableClose: true,
  //   });
  //   return dialogRef;
  // }
}
