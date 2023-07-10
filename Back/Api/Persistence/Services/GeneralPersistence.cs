using Persistence.Contexts;
using Persistence.Interfaces;


namespace Persistence.Services
{
    public class GeneralPersistence : IGeneralPersistence
    {
        private readonly ApplicationDbContext _db;

        public GeneralPersistence(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _db.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }
        public void DeleteRange<T>(T entity) where T : class
        {
            _db.RemoveRange(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
