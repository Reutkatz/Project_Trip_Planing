import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comp/home/home.component';
import { SignInComponent } from './comp/sign-in/sign-in.component';
import { DialogComponent } from './comp/dialog/dialog.component';
import { TripFormComponent } from './comp/trip-form/trip-form.component';
import { AddPlaceComponent } from './comp/add-place/add-place.component';
import { CategoriesComponent } from './comp/categories/categories.component';
import { BestTripComponent } from './comp/best-trip/best-trip.component';
import { LogInComponent } from './comp/log-in/log-in.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Home', title: 'Sail&Sea-Home', component: HomeComponent },
  { path: 'SignIn', title: 'Sail&Sea-Register', component: SignInComponent },
  { path: 'Login', title: 'Sail&Sea-LogIn', component: LogInComponent },
  { path: 'form', title: 'Sail&Sea-form', component: TripFormComponent },
  { path: 'bestTrip', title: 'Sail&Sea-bestTrip', component: BestTripComponent },
  { path: 'addPlace', title: 'Sail&Sea-form', component: AddPlaceComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'Dialog/:title/:context', component: DialogComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
