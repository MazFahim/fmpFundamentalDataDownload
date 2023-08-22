using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class PriceTargetsSummaryForSymbol
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public int? LastMonth { get; set; }
        public decimal? LastMonthAvgPriceTarget { get; set; }
        public int? LastQuarter { get; set; }
        public decimal? LastQuarterAvgPriceTarget { get; set; }
        public int? LastYear { get; set; }
        public decimal? LastYearAvgPriceTarget { get; set; }
        public int? AllTime { get; set; }
        public decimal? AllTimeAvgPriceTarget { get; set; }
        public string Publishers { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
    }
}
