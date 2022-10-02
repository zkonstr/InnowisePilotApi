using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnowisePilotApi.Models
{
    public class Fridge
    {
        [Key]
        public int FridgeId { get; set; }
        [Required]
        public string FridgeName { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public FridgeModel Model { get; set; }

    }
}
