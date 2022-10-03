using System.ComponentModel.DataAnnotations;

namespace InnowisePilotApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int DefaultQuantity { get; set; }

    }
}
