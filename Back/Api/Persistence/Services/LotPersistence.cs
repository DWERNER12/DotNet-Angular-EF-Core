using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;


namespace Persistence.Services
{
    public class LotPersistence : ILotPersistence
    {
        private readonly ApplicationDbContext _db;

        public LotPersistence(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Lot>> GetAllLotsAsync(bool includeEvents)
        {
            IQueryable<Lot> query = _db.Lots;

            if (includeEvents) query = query.Include(x => x.Event);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Lot>> GetAllLotsByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Lot> query = _db.Lots;

            if (includeEvents) query = query.Include(x => x.Event);

            query = query.AsNoTracking().Where(x => x.Name.ToLower().Contains(name.ToLower())).OrderBy(x => x.Id);

            return await query.ToListAsync();
        }

        public async Task<Lot> GetLotsByIdAsync(int lotId, bool includeEvents)
        {
            IQueryable<Lot> query = _db.Lots;

            if (includeEvents) query = query.Include(x => x.Event);

            query = query.AsNoTracking().Where(x => x.Id == lotId).OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
