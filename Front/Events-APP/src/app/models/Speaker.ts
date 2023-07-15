import { SocialNetwork } from "./SocialNetwork";
import { Event } from "./Event";

export interface Speaker {
    id:number;  
    name: string;  
    description: string;  
    imageURL: string;  
    phone: string;  
    email: string;  
    createdAt: Date;  
    events: Event[];  
    socialNetworks: SocialNetwork[];   
}
