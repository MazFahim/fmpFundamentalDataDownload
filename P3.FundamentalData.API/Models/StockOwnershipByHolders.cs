using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class StockOwnershipByHolders
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public string InvestorName { get; set; }
        public long? Cik { get; set; }
        public DateTime? FilingDate { get; set; }
        public string SecurityName { get; set; }
        public string TypeOfSecurity { get; set; }
        public long? SecurityCusip { get; set; }
        public string SharesType { get; set; }
        public string PutCallShare { get; set; }
        public string InvestmentDiscretion { get; set; }
        public string IndustryTitle { get; set; }
        public float? Weight { get; set; }
        public float? LastWeight { get; set; }
        public float? ChangeInWeight { get; set; }
        public float? ChangeInWeightPercentage { get; set; }
        public double? MarketValue { get; set; }
        public double? LastMarketValue { get; set; }
        public double? ChangeInMarketValue { get; set; }
        public float? ChangeInMarketValuePercentage { get; set; }
        public long? SharesNumber { get; set; }
        public long? LastSharesNumber { get; set; }
        public long? ChangeInSharesNumber { get; set; }
        public float? ChangeInSharesNumberPercentage { get; set; }
        public double? QuarterEndPrice { get; set; }
        public double? AvgPricePaid { get; set; }
        public string IsNew { get; set; }
        public string IsSoldOut { get; set; }
        public float? Ownership { get; set; }
        public float? LastOwnership { get; set; }
        public float? ChangeInOwnership { get; set; }
        public float? ChangeInOwnershipPercentage { get; set; }
        public long? HoldingPeriod { get; set; }
        public DateTime? FirstAdded { get; set; }
        public double? Performance { get; set; }
        public float? PerformancePercentage { get; set; }
        public double? LastPerformance { get; set; }
        public double? ChangeInPerformance { get; set; }
        public string IsCountedForPerformance { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
