using Domain;

namespace Persistence.Interfaces
{
    public interface IEventPersistence
    {
        Task<List<Event>> GetAllEventsByNameAsync(string name, bool includeSpeakers);
        Task<List<Event>> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventsByIdAsync(int eventId, bool includeSpeakers);
    }
}
