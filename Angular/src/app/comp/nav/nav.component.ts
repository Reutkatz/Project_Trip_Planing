import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.css'],
    standalone: false
})

export class NavComponent implements OnInit {

 public u: UserService;

  constructor(private r: Router, u: UserService) { 
      this.u=u;      
     }

  
 
  ngOnInit(): void {
  }

  Number():Number{
     return Number(this.u.currentUser.role)
  }
  details() {
    this.r.navigate(['SignIn']);
  }
  disconnect() {
    this.u.logout();
    this.r.navigate(['Home']);
  }
}
