using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class InstitutionalHoldingsPortfolioPositionsSummary
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public string InvestorName { get; set; }
        public long? Cik { get; set; }
        public long? PortfolioSize { get; set; }
        public long? SecuritiesAdded { get; set; }
        public long? SecuritiesRemoved { get; set; }
        public decimal? MarketValue { get; set; }
        public decimal? PreviousMarketValue { get; set; }
        public decimal? ChangeInMarketValue { get; set; }
        public decimal? ChangeInMarketValuePercentage { get; set; }
        public long? AverageHoldingPeriod { get; set; }
        public long? AverageHoldingPeriodTop10 { get; set; }
        public long? AverageHoldingPeriodTop20 { get; set; }
        public float? Turnover { get; set; }
        public float? TurnoverAlternateSell { get; set; }
        public float? TurnoverAlternateBuy { get; set; }
        public decimal? Performance { get; set; }
        public decimal? PerformancePercentage { get; set; }
        public decimal? LastPerformance { get; set; }
        public decimal? ChangeInPerformance { get; set; }
        public decimal? Performance1year { get; set; }
        public decimal? PerformancePercentage1year { get; set; }
        public decimal? Performance3year { get; set; }
        public decimal? PerformancePercentage3year { get; set; }
        public decimal? Performance5year { get; set; }
        public decimal? PerformancePercentage5year { get; set; }
        public decimal? PerformanceSinceInception { get; set; }
        public decimal? PerformanceSinceInceptionPercentage { get; set; }
        public decimal? PerformanceRelativeToSP500Percentage { get; set; }
        public decimal? Performance1yearRelativeToSP500Percentage { get; set; }
        public decimal? Performance3yearRelativeToSP500Percentage { get; set; }
        public decimal? Performance5yearRelativeToSP500Percentage { get; set; }
        public decimal? PerformanceSinceInceptionRelativeToSP500Percentage { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
