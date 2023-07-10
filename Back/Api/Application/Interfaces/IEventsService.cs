using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventsService
    {
        Task<Event> AddEvent(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);
        Task<List<Event>> GetAllEventsAsync(bool includeSpeakers = false);
        Task<List<Event>> GetAllEventsByNameAsync(string name, bool includeSpeakers = false);
        Task<Event> GetEventsByIdAsync(int eventId, bool includeSpeakers = false);
    }
}
