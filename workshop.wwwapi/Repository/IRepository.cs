using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        //Band Operations 
        Task<IEnumerable<Band>> GetAllBands();
        Task<Band> GetABand(int id);
        Task<BandMember> GetMemberById(int id);
        
        //BandMember Operations
        Task<IEnumerable<BandMember>> GetAllBandMembers();
        Task<BandMember> UpdateBandMember(int id, BandMember entity);

    }
}
