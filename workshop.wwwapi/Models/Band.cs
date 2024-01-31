using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("bands")]
    public class Band
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("number_of_members")]
        public int NumberOfMembers { get; set; }

     
    }
}
