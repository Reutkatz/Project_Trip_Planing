import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User, userRole } from 'src/app/models/user';
import { ApiService } from 'src/app/service/api.service';
import { UserService } from 'src/app/service/user.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.css'],
    standalone: false
})
export class SignInComponent implements OnInit {
  myForm: FormGroup = new FormGroup({});
  currentUser: User = new User();
  passValidation: string = "";
  public u: UserService;
  constructor(
    private r: Router,
     u: UserService,
    private a: ApiService,
    private dialog: MatDialog,
  ) {
    this.u=u;
  }

  ngOnInit() {
    this.myForm = new FormGroup({
      'Name': new FormControl(null, [this.isValidName.bind(this)]),
      'email': new FormControl(null, [this.isValidEmail.bind(this)]),
      'pass': new FormControl(null, [this.isValidPassword.bind(this)]),
      'passValidation': new FormControl(null, [this.ismatched.bind(this)]),
      'role': new FormControl(userRole.User, [Validators.required])
    });
  }

  get myMail() { return this.myForm.controls['email']; }
  get myPass() { return this.myForm.controls['pass']; }
  get myPassV() { return this.myForm.controls['passValidation']; }
  get myFN() { return this.myForm.controls['Name']; }

  send() {
    if (!this.u.isConnected) {
      this.addUser();
    } else {
      this.updateUser();
    }
  }

  updateUser() {
    const updatedUser: User = {
      id: this.currentUser.id,
      name: this.myForm.value.Name,
      email: this.myForm.value.email,
      password: this.myForm.value.pass,
      role: this.myForm.value.role
    };
    
    this.u.updateUser(updatedUser).subscribe({
      next: res => {
        this.r.navigate(['Home']);
      },
      error: err => console.log(err)
    });
  }

  addUser() {
    const newUser: User={
      id: this.currentUser.id, 
      name: this.myForm.value.Name,
      email: this.myForm.value.email,
      password: this.myForm.value.pass,
      role: this.myForm.value.role
    };

    this.u.addUser(newUser).subscribe({
      next: () => {
          this.r.navigate(['Home']);
      },
      error: (err) => {
          console.error('SighIn failed:', err);
          this.r.navigate(['Login']);
      }
  });
  }

  deleteUser() {
    this.u.deleteUser(this.currentUser.id).subscribe(() => {
      this.dialog.open(DialogComponent, {
        data: {
          subject: 'Success',
          title: 'Success',
          context: 'Successfully removed from the system',
          end: 'Close'
        }
      });
      this.r.navigate(['Home']);
    });
  }

  isValidName(name: AbstractControl) {
    if (!name.value) return { 'req': true };
    if (name.value.length < 3) return { 'min': true };
    if (!/^[א-ת\s]+$/.test(name.value) && !/^[a-zA-Z]+$/.test(name.value)) {
      return { 'notvalid': true };
    }
    return null;
  }

  isValidEmail(email: AbstractControl) {
    if (!email.value) return { 'req': true };
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value)) {
      return { 'notvalid': true };
    }
    return null;
  }

  isValidPassword(password: AbstractControl) {
    if (!password.value) return { 'req': true };
    if (password.value.length < 6) return { 'min': true };
    if (!/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/.test(password.value)) {
      return { 'notvalid': true };
    }
    return null;
  }

  ismatched(password: AbstractControl) {
    if (!password.value) return { 'req': true };
    if (password.value !== this.myPass.value) return { 'notvalid': true };
    return null;
  }
}
