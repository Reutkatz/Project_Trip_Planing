import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { TripService } from 'src/app/service/trip.service';
import { Category } from 'src/app/models/category';
import { Trip } from 'src/app/models/trip';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-best-trip',
  templateUrl: './best-trip.component.html',
  styleUrls: ['./best-trip.component.css'], 
  standalone:false
})
export class BestTripComponent implements OnInit {
  bestTripPlaces:Observable<Category[]> =new Observable<any[]>;
  bestTripPlaces$:Category[]=[];
  selectedTrip: Trip=new Trip();


  constructor(private tripService: TripService) {}

  ngOnInit() {this.selectedTrip=this.tripService.selectedTrip; this.bestTripPlaces=this.tripService.bestTripPlaces;
    this.bestTripPlaces.subscribe(places => {
      this.bestTripPlaces$ = places;
    })
  }

}
