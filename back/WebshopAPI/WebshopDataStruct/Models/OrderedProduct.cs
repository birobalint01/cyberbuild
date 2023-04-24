namespace WebshopCommon.Models
{
    [Table("OrderedProducts")]
    public class OrderedProduct
    {

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int PricePerUnit { get; set; }


    }
}
