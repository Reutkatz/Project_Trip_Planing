import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ApiService } from './api.service';
import { User } from '../models/user';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private userKey = 'currentUser';  
  public currentUser: User = new User();  
  public isConnected: boolean = false; 

  constructor(private http: HttpClient, private api: ApiService) { 
    const savedUser = localStorage.getItem(this.userKey);
    if (savedUser) {
      this.currentUser = JSON.parse(savedUser) as User; 
      this.isConnected = true;
    }
  }

  isAuthenticeted$=new BehaviorSubject<boolean>(!!localStorage.getItem('appSession'));

  get isAuthenticeted():boolean{
   return this.isAuthenticeted$.getValue();
  }

  public getUserByMail(email: any): Observable<User> {
    const url = `${this.api.baseUrl}/User/getUserByMail`;
    return this.http.get<any>(`${url}/${email}`);
  }

  public getById(id: number): Observable<any> {
    const url = `${this.api.baseUrl}/User`;
    return this.http.get<any>(`${url}/${id}`);
  }

  public login(u: any): Observable<any> {
    const url = `${this.api.baseUrl}/Auth/login`;
    return this.http.post<any>(url, u).pipe(
        tap({
            next: (response) => {
                localStorage.setItem('appSession', JSON.stringify({ token: response.token }));
                this.getUserByMail(u.email).subscribe({
                    next: (res) => {
                        console.log(res);
                        localStorage.setItem('currentUser', JSON.stringify(res));
                        this.currentUser = res;
                        this.isConnected = true;
                    },
                    error: (err) => {
                        console.log(err);
                    }
                });
            }
        })
    );
}


  public addUser(u: User): Observable<any> {
    const url = `${this.api.baseUrl}/Auth/signUp`;
    return this.http.post<any>(url, u).pipe(
      tap({
          next: (response) => {
              localStorage.setItem('appSession', JSON.stringify({ token: response.token }));
              localStorage.setItem('currentUser', JSON.stringify(u));
              this.currentUser = u;
              this.isConnected = true;
          }
      })
  );
}

  public updateUser(u: User): Observable<User> {
    const url = `${this.api.baseUrl}/User`;
    const res=  this.http.put<any>(url, u);
    this.currentUser=u;
    localStorage.setItem('currentUser', JSON.stringify(u));
    console.log(typeof(res));
    console.log(res);
    return res;
  }

  public deleteUser(code: number) {
    const url = `${this.api.baseUrl}`;
    return this.http.delete(`${url}/User/${code}`)
  }

  logout() {
       this.currentUser=new User();
       this.isConnected=false;
       localStorage.removeItem('appSession');
       localStorage.removeItem('currentUser');
     }
}