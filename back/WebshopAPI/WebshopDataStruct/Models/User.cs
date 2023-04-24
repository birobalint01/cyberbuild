
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

        [Required]
        public string Password { get; set; }

        [Required]
        public EUserType UserType { get; set; }

        public DateTime? LastLogon { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
