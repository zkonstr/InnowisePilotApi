using System.ComponentModel.DataAnnotations;

namespace InnowisePilotApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int DefaultQuantity { get; set; }

    }
}
