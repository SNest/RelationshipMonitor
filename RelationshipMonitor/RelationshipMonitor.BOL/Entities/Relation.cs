using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationshipMonitor.BOL.Entities
{
    public class Relation
    {
        [Key]
        [Required]
        public int RelationId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime StartDate { get; set; }


        public int? Partner1Id { get; set; }
        public int? Partner2Id { get; set; }

        [NotMapped]
        [ForeignKey("Partner1Id")]
        public User Partner1 { get; set; }
        [NotMapped]
        [ForeignKey("Partner2Id")]
        public User Partner2 { get; set; }

    }
}
