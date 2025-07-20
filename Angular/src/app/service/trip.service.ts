import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  Observable} from 'rxjs';
import { ApiService } from './api.service';
import { Trip } from '../models/trip';
import { Category } from '../models/category';


@Injectable({
  providedIn: 'root'
})
export class TripService {

  bestTripPlaces: Observable<Category[]> =new Observable<any[]>;
  selectedTrip: Trip =new Trip();

  constructor(private http: HttpClient, private api: ApiService) { }
  public addTrip(trip: Trip): Observable<boolean> {
        return this.http.post<boolean>(`${this.api.baseUrl}/Trip`, trip);
      }
      public bestTrip(trip: Trip): Observable<Category[]> {  
        this.selectedTrip=trip;      
       this.bestTripPlaces = this.http.post<Category[]>(`${this.api.baseUrl}/Trip/getBestTrip`, trip)
      return this.bestTripPlaces;}
}