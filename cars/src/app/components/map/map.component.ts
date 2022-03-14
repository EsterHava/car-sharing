import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {

  travel: any;
  icon:string;

  constructor( @Inject(MAT_DIALOG_DATA) public travell:any) { }

  ngOnInit(): void {
    this.travel=this.travell;
    this.icon='https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|008000';
  }

 
onMouseOver(infoWindow:any, gm:any) {

  if (gm.lastOpen != null) {
      gm.lastOpen.close();
  }

  gm.lastOpen = infoWindow;

  infoWindow.open();
}

}
