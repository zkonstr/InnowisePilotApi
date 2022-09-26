using System.ComponentModel.DataAnnotations;

namespace InnowisePilotApi.Models
{
    public class FridgeModel
    {
        [Key]
        public int FridgeModelId { get; set; }
        public string FridgeModelName { get; set; }
        public int ModelCreationYear { get; set; }
    }
}
