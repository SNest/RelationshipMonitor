using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelationshipMonitor.Mobile.Models
{
    public sealed class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Role { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Activity> Activities { get; set; }

        public User()
        {
            Relations = new List<Relation>();

            Events = new List<Event>();

            Activities = new List<Activity>();
        }
    }
}
