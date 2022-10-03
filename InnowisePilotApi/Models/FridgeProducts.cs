using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace InnowisePilotApi.Models
{
    public class FridgeProducts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey ("ProductId")]
        [Required]
        public Product Product { get; set; }
        [Required]
        public int FridgeID { get; set; }
        [ForeignKey("FridgeID")]
        [Required]
        public Fridge Fridge { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
