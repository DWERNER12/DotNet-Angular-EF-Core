

namespace Domain
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public DateTime? DateInicial { get; set; }
        public DateTime? DateFinal { get; set; }
        public DateTime CreatedAt { get; set; }

        public Event Event { get; set; }
    }
}
