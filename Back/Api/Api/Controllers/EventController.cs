using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EventController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Event> _Event = new Event[]
        {
            new Event()
            {
                EventName = "Test1",
                EventLot = "1º Lote",
                QuantityPeopleLimit = 250,
                LocalEvent = "São Paulo",
                DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImageUrl ="Test.png"
            },
            new Event()
            {
                EventName = "Test2",
                EventLot = "2º Lote",
                QuantityPeopleLimit = 350,
                LocalEvent = "São Paulo",
                DateEvent = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy"),
                ImageUrl ="Test.png"
            }
        };


        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _Event;
        }
        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            var eventDb = _db.Events.Where(x => x.EventId == id).FirstOrDefault();
            return eventDb;
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> Create(string name)
        {
            var newEvent = _Event.Where(x => x.EventName == name).FirstOrDefault();
            
            await _db.Events.AddAsync(newEvent);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
