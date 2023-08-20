using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class StockFInancialScores
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public float? AltmanZScore { get; set; }
        public int? PiotroskiScore { get; set; }
        public float? WorkingCapital { get; set; }
        public float? TotalAssets { get; set; }
        public float? RetainedEarnings { get; set; }
        public float? EBIT { get; set; }
        public float? MarketCap { get; set; }
        public float? TotalLiabilities { get; set; }
        public float? Revenue { get; set; }
        [Required]
        public DateTime dtExecuted { get; set; } = DateTime.Now;

        [Required]
        public int flag { get; set; } = 0;
    }
}
