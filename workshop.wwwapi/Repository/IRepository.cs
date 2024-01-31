using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Band>> Get();
     
        Task<Band> GetBand(int id);
        Task<IEnumerable<BandMember>> GetMembers();

    }
}
