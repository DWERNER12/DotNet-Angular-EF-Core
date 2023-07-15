import { Component, OnInit, TemplateRef } from '@angular/core';

import { Event } from "./../models/Event";
import { EventService } from '../services/event.service';

import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
  
})
export class EventsComponent implements OnInit {
  public modalRef?: BsModalRef;
  public events: Event[] = [];
  public eventsFilters: Event[] = [];
  public widthImg: number = 50; 
  public heightImg: number = 50;
  public marginImg: number = 2;
  public isExpand: boolean = false;
  private _filterList: string = '';
  
  
  public get filterList(): string{
    return this._filterList;
  }
  public set filterList(value: string){
    this._filterList = value;
    // filtrar direto com POO
    this.eventsFilters = this.events.filter((event) =>
        event.name.toLowerCase().includes(this.filterList.toLowerCase()) ||
        event.local.toLowerCase().includes(this.filterList.toLowerCase()) ||
        event.date?.toString().toLowerCase().includes(this.filterList.toLowerCase())
      ); 
  }

  constructor(
    private eventservice: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEvents();

  }
  public expandImg(): void {
    this.isExpand = !this.isExpand;
    if (this.isExpand) {
      this.widthImg = 50;
      this.heightImg= 50;
    } else {
      this.widthImg = 100;
      this.heightImg = 90;
    }
  }
 
  public getEvents(): void {
    this.eventservice.getEvents().subscribe({
      next:(_events: Event[]) => {
        this.events = _events;
        this.eventsFilters = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Eventos', 'Erro!', error);
      },
      complete: () => this.spinner.hide()
  });
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso!', 'Deletado!');
  }
 
  decline(): void {
    this.modalRef?.hide();
  }
}