namespace WebshopCommon.Models
{
    [Table("Orders")]
    public class Order
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public EPayment Payment { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public EStatus Status { get; set; } = EStatus.PROCESSING;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [NotMapped]
        public IEnumerable<OrderedProduct> Products { get; set; }

    }
}
