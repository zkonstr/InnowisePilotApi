using System.ComponentModel.DataAnnotations;

namespace InnowisePilotApi.Models
{
    public class FridgeModel
    {
        [Key]
        public int FridgeModelId { get; set; }
        [Required]
        public string FridgeModelName { get; set; }
        [Required]
        public int ModelCreationYear { get; set; }
    }
}
