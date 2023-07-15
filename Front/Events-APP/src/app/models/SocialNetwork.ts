import { Speaker } from "./Speaker";
import { Event } from "./Event";

export interface SocialNetwork {
    id: number;
    name: string;
    uRL: string; 
    eventId?: number; 
    speakerId?: number;
    createdAt: Date; 
    event: Event;
    speaker: Speaker;
}
