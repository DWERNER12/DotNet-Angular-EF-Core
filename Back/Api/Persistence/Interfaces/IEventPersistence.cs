using Domain;

namespace Persistence.Interfaces
{
    public interface IEventPersistence
    {
        Task<List<Event>> GetAllEventsByNameAsync(string name, bool includeSpeakers = false);
        Task<List<Event>> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event> GetEventsByIdAsync(int eventId, bool includeSpeakers = false);
    }
}
