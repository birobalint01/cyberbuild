namespace WebshopCommon.Models
{
    [Table("Logs")]
    public class Log
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public string UserEmail { get; set; } = "System";

        [Required]
        public ESeverity Severity { get; set; }

        public string? Message { get; set; }
    }
}
