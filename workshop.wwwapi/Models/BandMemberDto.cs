using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class BandMemberDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BandDto Band { get; set; }
    }
}
