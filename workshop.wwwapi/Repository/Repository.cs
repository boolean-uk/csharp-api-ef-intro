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
            return await _databaseContext.Bands.ToListAsync();
        }
       
    }
}
