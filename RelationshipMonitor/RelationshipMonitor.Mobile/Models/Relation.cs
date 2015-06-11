using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationshipMonitor.Mobile.Models
{
    public class Relation
    {
        [Key]
        [Required]
        public int RelationId { get; set; }

        //[ForeignKey("User1")]


        //[ForeignKey("User2")]

        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime StartDate { get; set; }


        public int? Partner1Id { get; set; }
        [ForeignKey("Partner1Id")]
        public User Partner1 { get; set; }

        public int? Partner2Id { get; set; }
        [ForeignKey("Partner2Id")]
        public User Partner2 { get; set; }

    }
}
