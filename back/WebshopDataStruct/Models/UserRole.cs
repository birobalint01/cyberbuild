namespace WebshopCommon.Models
{
    [Table("UserRoles")]
    public class UserRole
    {

        [Required]
        public string Email { get; set; }
        
        [Required]
        public int RoleID { get; set; }

    }
}
