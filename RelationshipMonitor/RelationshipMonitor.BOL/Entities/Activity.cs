using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationshipMonitor.BOL.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
 
        public int? CreatorId { get; set; }
        public int? RecipientId { get; set; }
        public int Estimate { get; set; }


        [ForeignKey("CreatorId")]
        public virtual User User1 { get; set; }
        [ForeignKey("RecipientId")]
        public virtual User User2 { get; set; }
    }
}
