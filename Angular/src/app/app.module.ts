import { NgModule } from '@angular/core';
import {
  MatDialogModule,
} from '@angular/material/dialog';
import { Component } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule, JsonPipe } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AppComponent } from './app.component';
import { HomeComponent } from './comp/home/home.component';
import { NavComponent } from './comp/nav/nav.component';
import { SignInComponent } from './comp/sign-in/sign-in.component';
import { LogInComponent } from './comp/log-in/log-in.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { AsyncPipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatTooltipModule } from '@angular/material/tooltip';
import { AboutComponent } from './comp/about/about.component';
import { DialogComponent } from './comp/dialog/dialog.component';
import { AddPlaceComponent } from './comp/add-place/add-place.component';
import { CategoriesComponent } from './comp/categories/categories.component';
import { BestTripComponent } from './comp/best-trip/best-trip.component';
import { TripFormComponent } from './comp/trip-form/trip-form.component';
import { tokenInterceptor } from './token.interceptor';
import { errorInterceptor } from './error.interceptor';

@NgModule({ declarations: [
        AppComponent,
        HomeComponent,
        NavComponent,
        SignInComponent,
        LogInComponent,
        AboutComponent,
        DialogComponent,
        AddPlaceComponent,
        CategoriesComponent,
        TripFormComponent,BestTripComponent
    ],
    bootstrap: [AppComponent], imports: [MatDialogModule,
        MatMenuModule,
        MatTableModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        JsonPipe,
        MatButtonModule,
        MatTooltipModule,
        MatSlideToggleModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        FormsModule,
        MatIconModule,
        MatCardModule,
        MatTabsModule,
        FormsModule,
        MatAutocompleteModule,
        ReactiveFormsModule,
        AsyncPipe,
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,ReactiveFormsModule,
         MatFormFieldModule,
         MatInputModule,
         MatButtonModule,
         MatSelectModule,
       
        
      ], providers: [  
        provideHttpClient(withInterceptors([tokenInterceptor,errorInterceptor])),
        provideHttpClient(withInterceptorsFromDi())
    ] })
export class AppModule { }