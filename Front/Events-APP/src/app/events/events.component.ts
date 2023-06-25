import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [
    {
      EventName: "Angular 11",
      LocalEvent: "São Paulo",
    },
    {
      EventName: "DotNet",
      LocalEvent: "Rio de Janeiro",
    },
    {
      EventName: "TypeScript",
      LocalEvent: "Salvador",
    },
  ]
    
  

  constructor() { }

  ngOnInit() {
  }

}
