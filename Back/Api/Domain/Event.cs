

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int QuantityPeople { get; set; }
        public string Lot { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Lot> Lots { get; set; }
        public ICollection<SocialNetwork> SocialNetworks { get; set; }
        public ICollection<EventAssignedSpeaker> EventsAssignedSpeakers { get; set; }
    }
}
