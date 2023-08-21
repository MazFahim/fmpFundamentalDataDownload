using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public int Year { get; set; }
        public double? Revenue { get; set; }
        public float? RevenuePercentage { get; set; }
        public long? CapitalExpenditure { get; set; }
        public float? CapitalExpenditurePercentage { get; set; }
        public double? Price { get; set; }
        public float? Beta { get; set; }
        public long? DilutedSharesOutstanding { get; set; }
        public float? CostofDebt { get; set; }
        public float? TaxRate { get; set; }
        public float? AfterTaxCostOfDebt { get; set; }
        public float? RiskFreeRate { get; set; }
        public float? MarketRiskPremium { get; set; }
        public float? CostOfEquity { get; set; }
        public double? TotalDebt { get; set; }
        public double? TotalEquity { get; set; }
        public double? TotalCapital { get; set; }
        public float? DebtWeighting { get; set; }
        public float? EquityWeighting { get; set; }
        public float? Wacc { get; set; }
        public long? OperatingCashFlow { get; set; }
        public long? PvLfcf { get; set; }
        public long? SumPvLfcf { get; set; }
        public long? LongTermGrowthRate { get; set; }
        public long? FreeCashFlow { get; set; }
        public double? TerminalValue { get; set; }
        public double? PresentTerminalValue { get; set; }
        public double? EnterpriseValue { get; set; }
        public long? NetDebt { get; set; }
        public double? EquityValue { get; set; }
        public double? EquityValuePerShare { get; set; }
        public double? FreeCashFlowT1 { get; set; }
        public float? OperatingCashFlowPercentage { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
