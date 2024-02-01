using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
       

        public async Task<IEnumerable<Band>> GetAllBands()
        {
            return await _databaseContext.Bands.Include(band => band.Members).ToListAsync();
        }

        public async Task<Band> GetABand(int id)
        {
            return await _databaseContext.Bands.FirstAsync(b => b.Id == id);
        }

        public async Task<BandMember> GetMemberById(int id)
        {
            var result = await _databaseContext.BandMembers.FirstOrDefaultAsync(b => b.Id == id);
            
            return result;
        }

        public async Task<IEnumerable<BandMember>> GetAllBandMembers()
        {
            return await _databaseContext.BandMembers.Include(b => b.Band).ToListAsync();
        }

        public async Task<BandMember> UpdateBandMember(int id, BandMember entity)
        {
            throw new NotImplementedException();
            //var result = _databaseContext.BandMembers.Update(entity);
            //await _databaseContext.SaveChangesAsync();
     
        }
    }
}
