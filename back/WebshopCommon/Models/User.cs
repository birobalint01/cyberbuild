
namespace WebshopCommon.Models
{
    [Table("Users")]
    public class User
    {

        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Password { get; set; }

        [Required]
        public EUserType UserType { get; set; }

        public DateTime? LastLogon { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        [NotMapped]
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
