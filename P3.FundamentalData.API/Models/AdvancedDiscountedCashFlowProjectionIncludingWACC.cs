using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class AdvancedDiscountedCashFlowProjectionIncludingWACC
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public string Year { get; set; }
        public double? Revenue { get; set; }
        public double? RevenuePercentage { get; set; }
        public long? Ebitda { get; set; }
        public double? EbitdaPercentage { get; set; }
        public long? Ebit { get; set; }
        public double? EbitPercentage { get; set; }
        public long? Depreciation { get; set; }
        public double? DepreciationPercentage { get; set; }
        public double? TotalCash { get; set; }
        public double? TotalCashPercentage { get; set; }
        public long? Receivables { get; set; }
        public double? ReceivablesPercentage { get; set; }
        public long? Inventories { get; set; }
        public double? InventoriesPercentage { get; set; }
        public double? Payable { get; set; }
        public double? PayablePercentage { get; set; }
        public long? CapitalExpenditure { get; set; }
        public double? CapitalExpenditurePercentage { get; set; }
        public double? Price { get; set; }
        public double? Beta { get; set; }
        public long? DilutedSharesOutstanding { get; set; }
        public double? CostofDebt { get; set; }
        public double? TaxRate { get; set; }
        public double? AfterTaxCostOfDebt { get; set; }
        public double? RiskFreeRate { get; set; }
        public double? MarketRiskPremium { get; set; }
        public double? CostOfEquity { get; set; }
        public double? TotalDebt { get; set; }
        public long? TotalEquity { get; set; }
        public double? TotalCapital { get; set; }
        public double? DebtWeighting { get; set; }
        public double? EquityWeighting { get; set; }
        public double? Wacc { get; set; }
        public double? TaxRateCash { get; set; }
        public long? Ebiat { get; set; }
        public long? Ufcf { get; set; }
        public long? SumPvUfcf { get; set; }
        public long? LongTermGrowthRate { get; set; }
        public long? TerminalValue { get; set; }
        public long? PresentTerminalValue { get; set; }
        public long? EnterpriseValue { get; set; }
        public double? NetDebt { get; set; }
        public double? EquityValue { get; set; }
        public double? EquityValuePerShare { get; set; }
        public long? FreeCashFlowT1 { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
