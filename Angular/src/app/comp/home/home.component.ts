import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/service/api.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    standalone: false
})
export class HomeComponent implements OnInit {

  constructor(public dialog: MatDialog, private r: Router,
      private a: ApiService) { }

  ngOnInit(): void {
 
  }
  openMe(){
    this.r.navigate(['form']);
  }
}