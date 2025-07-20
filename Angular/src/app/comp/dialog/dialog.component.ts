import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import {  Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.css'],
    standalone: false
})
export class DialogComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public p: any,
    public u: UserService,
    private dialog: MatDialog,
    private r: Router) { }

  end: string = "";
  title: string = "";
  context: string = "";
  cancle: string = ""

  open: boolean = false;
  numOfPlaces: number = 0;

  booking: any;

  ngOnInit(): void {
    if (this.p.subject == "Cancle") {
      this.open = true;
      this.cancle = this.p.cancle
    }
    this.title = this.p.title;
    this.end = this.p.end;
    this.context = this.p.context;
  }

  async remove() {
    debugger;
    const user = localStorage.getItem('currentUser');
    const u = JSON.parse(user!);
  }
}
