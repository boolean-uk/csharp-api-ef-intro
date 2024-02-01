using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("bandmember_instrument")]
    public class BandMemberInstrument
    {
        [Column("bandmemberid")]
        public int BandMemberId { get; set; }
        [Column("instrumentid")]
        public int InstrumentId { get; set; }
    }
}
