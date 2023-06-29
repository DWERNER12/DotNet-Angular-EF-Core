using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            query = query.OrderBy(x => x.Id);

            return await query.ToListAsync();
        }
        public async Task<List<Speaker>> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {

            IQueryable<Speaker> query = _db.Speakers
              .Include(x => x.SocialNetworks);

            if (includeEvents) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Event);

            query = query.OrderBy(x => x.Id).Where(x => x.Name.ToLower().Contains(name.ToLower()));

            return await query.ToListAsync();
        }
        public async Task<Speaker> GetSpeakersByIdAsync(int speakerId, bool includeEvents = false)
        {

            IQueryable<Speaker> query = _db.Speakers
              .Include(x => x.SocialNetworks);

            if (includeEvents) query = query.Include(x => x.EventsAssignedSpeakers)
                .ThenInclude(x => x.Event);

            query = query.Where(x => x.Id == speakerId);


            return await query.FirstOrDefaultAsync();
        }
    }
}
