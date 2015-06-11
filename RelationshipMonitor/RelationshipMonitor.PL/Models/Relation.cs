using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipMonitor.PL.Models
{
    public class Relation
    {
        public int RelationId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public int? Partner1Id { get; set; }
        public int? Partner2Id { get; set; }
    }
}
