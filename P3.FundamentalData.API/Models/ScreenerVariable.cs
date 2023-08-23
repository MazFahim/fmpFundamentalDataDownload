using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class ScreenerVariable
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string varType { get; set; }
        [Required]
        public string varName { get; set; } = "any";
        [Required]
        public string Category { get; set; }

        
    }
}
