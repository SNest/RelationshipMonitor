using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationshipMonitor.BOL.Entities
{
    public class Event
    {
        [Key]
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

        [NotMapped]
        [ForeignKey("CreatorId")]
        public virtual User User1 { get; set; }
        [NotMapped]
        [ForeignKey("RecipientId")]
        public virtual User User2 { get; set; }
    }
}
