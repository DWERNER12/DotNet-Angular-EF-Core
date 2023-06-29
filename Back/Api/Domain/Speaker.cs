

namespace Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<SocialNetwork> SocialNetworks { get; set; }
        public ICollection<EventAssignedSpeaker> EventsAssignedSpeakers { get; set; }
    }
}
