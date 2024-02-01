using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("bandmembers")]
    public class BandMember
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("fk_band_id")]
        [ForeignKey("Band")]
        public int BandId { get; set; }
        public Band Band { get; set; }
    }
}
