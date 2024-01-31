using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Band>> Get();
     
        Task<Band> GetBand(int id);
        Task<IEnumerable<BandMember>> GetMembers();

    }
}
