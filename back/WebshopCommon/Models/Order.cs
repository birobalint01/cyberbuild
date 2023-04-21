namespace WebshopCommon.Models
{
    [Table("Orders")]
    public class Order
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public EPayment Payment { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public EStatus Status { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
