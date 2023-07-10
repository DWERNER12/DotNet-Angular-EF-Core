using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;


namespace Persistence.Services
{
    public class SpeakerPersistence : ISpeakerPersistence
    {
        private readonly ApplicationDbContext _db;

        public SpeakerPersistence(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Speaker>> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _db.Speakers
              .Include(x => x.SocialNetworks);

            if (includeEvents) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Event);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToListAsync();
        }
        public async Task<List<Speaker>> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {

            IQueryable<Speaker> query = _db.Speakers
              .Include(x => x.SocialNetworks);

            if (includeEvents) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Event);

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Name.ToLower().Contains(name.ToLower()));

            return await query.ToListAsync();
        }
        public async Task<Speaker> GetSpeakersByIdAsync(int speakerId, bool includeEvents = false)
        {

            IQueryable<Speaker> query = _db.Speakers
              .Include(x => x.SocialNetworks);

            if (includeEvents) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Event);

            query = query.AsNoTracking().Where(x => x.Id == speakerId);


            return await query.FirstOrDefaultAsync();
        }
    }
}
