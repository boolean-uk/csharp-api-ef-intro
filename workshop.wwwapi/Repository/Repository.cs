using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
       

        public async Task<IEnumerable<Band>> Get()
        {
            return await _databaseContext.Bands.Include(band => band.Members).ToListAsync();
        }

        public async Task<Band> GetBand(int id)
        {
            return await _databaseContext.Bands.FirstAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BandMember>> GetMembers()
        {
            return await _databaseContext.BandMembers.Include(b => b.Band).ToListAsync();
        }
    }
}
