using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;

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
                Name = "ASP.NET CORE 6.0",
                Lot = "1º Lote",
                QuantityPeople = 250,
                Local = "São Paulo",
                Date = Convert.ToDateTime("24/08/2023"),
                ImageURL ="img1.png",
                Email = "teste@teste.com",
                Phone = "11123451234",
                CreatedAt = DateTime.Now,
            },
            new Event()
            {
                Name = "Angular 14",
                Lot = "2º Lote",
                QuantityPeople = 80,
                Local = "Rio de Janeiro",
                Date = Convert.ToDateTime("10/12/2023"),
                ImageURL ="img2.png",
                Email = "teste@teste.com",
                Phone = "11123451234",
                CreatedAt = DateTime.Now,
            }, 
            new Event()
            {
                Name = "EF Core 7.0.8",
                Lot = "2º Lote",
                QuantityPeople = 150,
                Local = "Paraiba",
                Date = Convert.ToDateTime("16/07/2023"),
                ImageURL ="img3.png",
                Email = "teste@teste.com",
                Phone = "11123451234",
                CreatedAt = DateTime.Now,
            }
        };
        [HttpGet]
        public List<Event> Get()
        {
            var eventDb = _db.Events.ToList();
            return eventDb;
        }
        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            var eventDb = _db.Events.Where(x => x.Id == id).FirstOrDefault();
            return eventDb;
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> Create(string name)
        {
            var newEvent = _Event.Where(x => x.Name == name).FirstOrDefault();
            
            await _db.Events.AddAsync(newEvent);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}
