using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventsDb = await _eventsService.GetAllEventsAsync(true);
                if (eventsDb == null) return NotFound("Nenhum evento encontrado!");

                return Ok(eventsDb);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Eventos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var eventDb = await _eventsService.GetEventsByIdAsync(id, true);
                if (eventDb == null) return NotFound("Nenhum evento encontrado!");

                return Ok(eventDb);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventoId{id}. Erro: {ex.Message}");
            }
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var eventDb = await _eventsService.GetAllEventsByNameAsync(name, true);
                if (eventDb == null) return NotFound("Nenhum evento encontrado!");

                return Ok(eventDb);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento {name}. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event model)
        {
            try
            {
                var newEvent = await _eventsService.AddEvent(model);
                if (newEvent == null) return BadRequest($"Erro ao tentar adicionar evento {model.Name}!");

                return Ok(newEvent);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar adicionar evento {model.Name}. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Event model)
        {
            try
            {
                var newEvent = await _eventsService.UpdateEvent(id, model);
                if (newEvent == null) return BadRequest($"Erro ao tentar editar eventoId{id} {model.Name}!");

                return Ok(newEvent);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar editar evento {model.Name}. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventsService.DeleteEvent(id) ? Ok("Deletado") : BadRequest("Evento não deletado"); 

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar deletar evento. Erro: {ex.Message}");
            }
        }

    }
}
