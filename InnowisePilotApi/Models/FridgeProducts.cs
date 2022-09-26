using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace InnowisePilotApi.Models
{
    public class FridgeProducts
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey ("ProductId")]
        public Product Product { get; set; }
        public int FridgeID { get; set; }
        [ForeignKey("FridgeID")]
        public Fridge Fridge { get; set; }
        public int Quantity { get; set; }
    }
}
