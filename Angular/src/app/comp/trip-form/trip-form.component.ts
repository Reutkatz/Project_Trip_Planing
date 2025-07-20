import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { TripService } from 'src/app/service/trip.service';
import { IsraelRegion, Trip } from 'src/app/models/trip';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-trip-form',
  standalone: false,
  templateUrl: './trip-form.component.html',
  styleUrls: ['./trip-form.component.css']
})
export class TripFormComponent {
  bestTripPlaces: Category[] = [];
  selectedTrip: Trip =new Trip();
  Region = IsraelRegion;
  tripForm: FormGroup;
  myForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private router: Router,private t:TripService) {
    this.tripForm = this.fb.group({
      title: ['', Validators.required],
      date: ['', Validators.required],
      budget: ['', [Validators.required, Validators.min(0)]],
      region: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      numOfAttractions: ['', [Validators.required, Validators.min(0)]],
      numOfTrails: ['', [Validators.required, Validators.min(0)]],
      numOfStoppingPlaces: ['', [Validators.required, Validators.min(0)]]
    });
  }

  get titleControl() { return this.tripForm.get('title'); }
  get dateControl() { return this.tripForm.get('date'); }
  get budgetControl() { return this.tripForm.get('budget'); }
  get regionControl() { return this.tripForm.get('region'); }
  get startTimeControl() { return this.tripForm.get('startTime'); }
  get endTimeControl() { return this.tripForm.get('endTime'); }
  get attractionsControl() { return this.tripForm.get('numOfAttractions'); }
  get trailsControl() { return this.tripForm.get('numOfTrails'); }
  get stoppingPlacesControl() { return this.tripForm.get('numOfStoppingPlaces'); }

  onSubmit() {
    if (this.tripForm.valid) {
      console.log('Trip form submitted:', this.tripForm.value);
      this.selectedTrip=this.tripForm.value;
      this.t.bestTrip(this.tripForm.value).subscribe(
        (data) => {
          console.log('Response data:', data);
          this.bestTripPlaces=data;          console.log('Response data:', this.bestTripPlaces);
         this.router.navigate(['bestTrip']);
        },
        (error) => {
          console.error('Error fetching places:', error);
        }
      );
      this.tripForm.reset();
      alert('הטיול נוסף בהצלחה!');
    }
  }
  isValidName(name: AbstractControl) {
    if (!name.value) return { 'req': true };
    if (name.value.length < 3) return { 'min': true };
    if (name.value && (!/^[א-ת\s]+$/.test(name.value) && !/^[a-zA-Z]+$/.test(name.value))) {
      return { 'notvalid': true };
    }
    return null;
  }
}