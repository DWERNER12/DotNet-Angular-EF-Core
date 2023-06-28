import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public eventsFilters: any = [];
  widthImg: number = 100; 
  marginImg: number = 2;
  isExpand: boolean = true;
  private _filterList: string = '';

  public get filterList(): string{
    return this._filterList;
  }
  public set filterList(value: string){
    this._filterList = value;
    // filtrar direto com POO
    this.eventsFilters = this.events.filter((event: {
      eventName: string;
      localEvent: string;
      dateEvent: string;
      }) =>
      event.eventName.toLowerCase().includes(this.filterList.toLowerCase()) ||
      event.localEvent.toLowerCase().includes(this.filterList.toLowerCase()) ||
      event.dateEvent.toLowerCase().includes(this.filterList.toLowerCase())
      ); 

    //this.events = this.filterList ? this.filterEvents(this.filterList) : this.events;  //filtrar com metodo a parte
  }

  // forma de filtrar criando metodo separados
  // filterEvents(filterOf: string): any {
  //   filterOf = filterOf.toLowerCase(); 
  //   return this.events.filter((event: { eventName: string; }) => event.eventName.toLowerCase().indexOf(filterOf) != -1);
  // }


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  expandImg() {
    this.isExpand = !this.isExpand;
    if (this.isExpand) {
          this.widthImg = 100;
        } else {
          this.widthImg = 25;
        }
  }

  public getEvents(): void {
    this.http.get('https://localhost:7068/api/event').subscribe(
      response => {
        this.events = response;
        this.eventsFilters = response;
      },
      error => console.log(error),
    );
  }

  

}