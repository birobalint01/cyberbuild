
namespace WebshopCommon.Models
{
    [Table("Roles")]
    public class Role
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

    }
}
