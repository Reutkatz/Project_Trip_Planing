import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { ApiService } from './api.service';
import { OpenHour } from '../models/openHour';

@Injectable({
    providedIn: 'root'
  })
export class CategoryService {
    constructor(private http: HttpClient, private api: ApiService) { }

  addCategory(type:string,category: Category): Observable<Category> {
    console.log(JSON.stringify(category));
    return this.http.post<Category>(`${this.api.baseUrl}/${type}`, category);
  }
  getCategory(type:string): Observable<Category[]>{
  const res= this.http.get<Category[]>(`${this.api.baseUrl}/${type}`);
  console.log("res"+res);
  return res;
  }
  ratePlace(type:string,id:number,rate: String): Observable<Category>{
    console.log("id",id);
    console.log("rate",rate);
    return this.http.put<Category>(`${this.api.baseUrl}/${type}/rate/${id}`,Number(rate));
  }
  addOpenHours(openHours: OpenHour[]): Observable<OpenHour[]> {
    return this.http.post<OpenHour[]>(`${this.api.baseUrl}/OpeningHours/list`, openHours);
  }
}