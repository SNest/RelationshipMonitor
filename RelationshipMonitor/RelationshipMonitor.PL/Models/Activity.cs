using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipMonitor.PL.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
 
        public int? CreatorId { get; set; }
        public int? RecipientId { get; set; }
        public int Estimate { get; set; }
    }
}
