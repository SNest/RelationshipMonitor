using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipMonitor.PL.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int? CreatorId { get; set; }
        public int? RecipientId { get; set; }
        public int Estimate { get; set; }

    }
}
