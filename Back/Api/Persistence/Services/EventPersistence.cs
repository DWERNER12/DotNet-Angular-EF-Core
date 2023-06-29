using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Interfaces;

namespace Persistence.Services
{
    public class EventPersistence : IEventPersistence
    {
        private readonly ApplicationDbContext _db;

        public EventPersistence(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Event>> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _db.Events
                .Include(x => x.SocialNetworks)
                .Include(x => x.Lots);

            if (includeSpeakers) query = query.Include(x => x.EventsAssignedSpeakers)
                    .ThenInclude(x => x.Speaker);

            query = query.OrderBy(x => x.Id);

            return await query.ToListAsync();
        }
        public async Task<Event> GetEventsByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _db.Events
               .Include(x => x.SocialNetworks)
               .Include(x => x.Lots);

            if (includeSpeakers) query = query.Include(x => x.EventsAssignedSpeakers)
                    .ThenInclude(x => x.Speaker);

            query = query.Where(x => x.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<Event>> GetAllEventsByNameAsync(string name, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _db.Events
              .Include(x => x.SocialNetworks)
              .Include(x => x.Lots);

            if (includeSpeakers) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Speaker);

            query = query.OrderBy(x => x.Id).Where(x => x.Name.ToLower().Contains(name.ToLower()));

            return await query.ToListAsync();
        }
    }
}
