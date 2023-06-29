

namespace Domain
{
    public class EventAssignedSpeaker
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public int EventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Speaker Speaker { get; set; }
        public Event Event { get; set; }
        public ICollection<EventAssignedSpeaker> EventsAssignedSpeakers { get; set; }
    }
}
