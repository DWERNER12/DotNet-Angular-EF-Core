using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public IEnumerable<Event> _Event = new Event[]
        {
            new Event()
            {
                EventId = 1,
                EventName = "Test",
                EventLot = "1º Lote",
                QuantityPeopleLimit = 10,
                LocalEvent = "São Paulo",
                DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImageUrl ="Test.png"
            },
            new Event()
            {
                EventId = 2,
                EventName = "Test",
                EventLot = "1º Lote",
                QuantityPeopleLimit = 10,
                LocalEvent = "São Paulo",
                DateEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImageUrl ="Test.png"
            }
        };


        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _Event;
        }
        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return _Event.Where(x => x.EventId == id);
        }
    }
}
