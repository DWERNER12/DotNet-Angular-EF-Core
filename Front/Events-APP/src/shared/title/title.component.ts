import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() title: string = '';
  @Input() iconClass: string = '';
  @Input() subtitle: string = 'Desde 2023';
  
  private _filterList: string = '';

  constructor() { }

  ngOnInit() {
  }

  public get filterList(): string{
    return this._filterList;
  }
}
