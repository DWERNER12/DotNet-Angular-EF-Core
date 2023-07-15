import { Event } from "./../models/Event";

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable()
export class EventService {
  baseURL = 'https://localhost:7068/api/event';

  constructor(private http: HttpClient) { }

  public getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseURL);
  }
  public getEventByName(name: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseURL}/name/${name}`);
  }
  public getEventById(id: number): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseURL}/${id}`);
  }
 
}
