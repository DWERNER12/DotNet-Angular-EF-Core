import { Event } from "./Event";

export interface Lot {
    id: number;
    name: string; 
    price: number; 
    quantity: number;
    eventId: number;
    dateInicial?: Date; 
    dateFinal?: Date; 
    createdAt: Date; 
    event: Event;
}
