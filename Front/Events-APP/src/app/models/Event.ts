import { Lot } from "./Lot";
import { SocialNetwork } from "./SocialNetwork";
import { Speaker } from "./Speaker";

export interface Event {
    id: number;
    local: string; 
    date?: Date; 
    createdAt: Date; 
    name: string; 
    quantityPeople: number; 
    imageURL: string; 
    email: string; 
    phone: string; 
    lots: Lot[]; 
    socialNetworks: SocialNetwork[]; 
    speakers: Speaker[]; 
}
