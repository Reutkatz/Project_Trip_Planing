import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { DayOfWeek, OpenHour } from 'src/app/models/openHour';
import { IsraelRegion } from 'src/app/models/trip';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-add-place',
  templateUrl: './add-place.component.html',
  styleUrls: ['./add-place.component.css']
  ,standalone:false
})
export class AddPlaceComponent implements OnInit {
  addForm: FormGroup;
  showOpenHoursForm:boolean= false; 
  type: string = "";
  placeId: number | null = null;
  openHours: OpenHour[] = [];
  daysOfWeek = Object.keys(DayOfWeek).filter(key => isNaN(Number(key)));
  regions = Object.keys(IsraelRegion)
    .filter(key => isNaN(Number(key)))
    .map(key => ({ name: key, value: IsraelRegion[key as keyof typeof IsraelRegion] }));

  constructor(
    private fb: FormBuilder, 
    private categoryService: CategoryService, 
    private router: Router
  ) {
    this.addForm = this.fb.group({
      name: ['', Validators.required],
      address: [''],
      rating: [0],
      reviewsCount:[0],
      price: ['', [Validators.min(0)]],
      website: [''],
      region: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.initializeOpeningHours();
  }

  initializeOpeningHours(): void {
    this.openHours = this.daysOfWeek.map(day => 
      new OpenHour(0, DayOfWeek[day as keyof typeof DayOfWeek] as DayOfWeek, '', '', 0)
    ); 
   }

  onTypeChange(event: any): void {
    this.type = event.value;
  }

  onSubmit(): void {
    if (this.addForm.valid) {
      const newCategory: Category = this.addForm.value;
      
      this.categoryService.addCategory(this.type, newCategory).subscribe(
        (createdPlace) => {
          alert('הקטגוריה נוספה בהצלחה!');
          console.log(createdPlace);
          this.placeId = createdPlace.id;
          this.openHours.forEach(hour => hour.PlaceId = this.placeId ?? 0);
          this.showOpenHoursForm = true;
        },
        (error) => console.error('Error adding category:', error)
      );
    }
  }

  submitOpeningHours(): void {
    if (this.placeId) {
      this.categoryService.addOpenHours(this.openHours).subscribe(
        () => {
          alert('שעות הפתיחה נוספו בהצלחה!');
          this.router.navigate(['/categories']);
        },
        (error) => console.error('Error adding opening hours:', error)
      );
    }
  }
}
