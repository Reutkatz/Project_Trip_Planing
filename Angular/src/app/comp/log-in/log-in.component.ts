import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/service/api.service';
import { UserService } from 'src/app/service/user.service';

@Component({
    selector: 'app-log-in',
    templateUrl: './log-in.component.html',
    styleUrls: ['./log-in.component.css'],
    standalone: false
})
export class LogInComponent implements OnInit {
 
  constructor(public r: Router,
    public u: UserService,
    public a: ApiService) { }

  myForm: FormGroup = new FormGroup({});
  failedConnected: boolean=false;
  ngOnInit() {

    this.myForm = new FormGroup(
      {
        'name': new FormControl(null, [Validators.required, this.isValidEmail.bind(this)]),
        'pass': new FormControl(null, [Validators.required])
      }
    );
  };

  get myPass() { return this.myForm.controls['pass'] }
  get myName() { return this.myForm.controls['name'] }

  send() {
         console.log(this.myForm.value.name);
         const req={"email":this.myForm.value.name,"password":this.myForm.value.pass}
        this.u.login(req).subscribe({
          next: () => {
              this.r.navigate(['Home']);
          },
          error: (err) => {
              console.error('Login failed:', err);
              this.failedConnected = true;
              this.r.navigate(['signUp']);
          }
      });
  }
  
 isValidEmail(email: AbstractControl) {
    if (!email.value)
      return { 'req': true };
    if (email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value)) {
      return { 'notvalid': true };
    }
    return null;
  }
}