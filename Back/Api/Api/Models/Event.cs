namespace Api.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string LocalEvent { get; set; }
        public string DateEvent { get; set; }
        public string EventName { get; set; }
        public int QuantityPeopleLimit { get; set; }
        public string EventLot { get; set; }
        public string ImageUrl { get; set;}
    }
}
