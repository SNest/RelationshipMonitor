using System.ComponentModel.DataAnnotations;

namespace RelationshipMonitor.PL.Models
{
    public sealed class User
    {
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
    }
}
