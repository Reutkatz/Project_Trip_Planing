import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
 
  constructor() {
    }

  baseRoute = "../../assets";
  baseUrl = 'https://localhost:7144/api';
  basePic = "../../assets/15.png";
  baseDate: Date = new Date();
  
}
