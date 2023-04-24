namespace WebshopCommon.Models
{
    [Table("Products")]
    public class Product
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
