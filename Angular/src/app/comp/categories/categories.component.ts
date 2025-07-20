import { Component } from '@angular/core';
import { CategoryService } from '../../service/category.service';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
  standalone:false

})
export class CategoriesComponent {
  places: Category[] = [];
  type:string='';

  constructor(private categoriesService: CategoryService) {}

  fetchPlaces(category: string) {
    this.type=category;
    this.categoriesService.getCategory(category).subscribe(
      (data) => {
        this.places=data;
      },
      (error) => {
        console.error('Error fetching places:', error);
      }
    );
  }
  ratePlace(type:string,id: number, rating: string) {
    this.categoriesService.ratePlace(type,id, rating).subscribe(
      (response) => {
        console.log('Rating submitted:', response);
        this.fetchPlaces(type);
      },
      (error) => {
        console.error('Error submitting rating:', error);
      }
    );
  }
}