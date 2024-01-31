using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class BandDto
    {      
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Formed { get; set; }
        public int MeembersCount { get; set; }

    }
}
