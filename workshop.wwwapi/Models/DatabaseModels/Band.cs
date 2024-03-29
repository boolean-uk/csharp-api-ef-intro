﻿using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("bands")]
    public class Band
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("genre")]
        public string Genre { get; set; }

        [Column("formed_year")]
        public int Formed { get; set; }


        [Column("members")]
        public int MembersCount { get; set; }

        public IEnumerable<BandMember> Members { get; set; }


    }
}
