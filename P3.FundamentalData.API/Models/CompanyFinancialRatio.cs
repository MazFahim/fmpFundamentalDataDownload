using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class CompanyFinancialRatio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        [Required]
        public string period { get; set; }
        [Column(TypeName = "float")]
        public double? currentRatio { get; set; }
        [Column(TypeName = "float")]
        public double? quickRatio { get; set; }
        [Column(TypeName = "float")]
        public double? cashRatio { get; set; }
        [Column(TypeName = "float")]
        public double? daysOfSalesOutstanding { get; set; }
        public double? DaysOfInventoryOutstanding { get; set; }
        public double? OperatingCycle { get; set; }
        public double? DaysOfPayablesOutstanding { get; set; }
        public double? CashConversionCycle { get; set; }
        public double? GrossProfitMargin { get; set; }
        public double? OperatingProfitMargin { get; set; }
        public double? PretaxProfitMargin { get; set; }
        public double? NetProfitMargin { get; set; }
        public double? EffectiveTaxRate { get; set; }
        public double? ReturnOnAssets { get; set; }
        public double? ReturnOnEquity { get; set; }
        public double? ReturnOnCapitalEmployed { get; set; }
        public double? NetIncomePerEBT { get; set; }
        public double? EbtPerEbit { get; set; }
        public double? EbitPerRevenue { get; set; }
        public double? DebtRatio { get; set; }
        public double? DebtEquityRatio { get; set; }
        public double? LongTermDebtToCapitalization { get; set; }
        public double? TotalDebtToCapitalization { get; set; }
        public double? InterestCoverage { get; set; }
        public double? CashFlowToDebtRatio { get; set; }
        public double? CompanyEquityMultiplier { get; set; }
        public double? ReceivablesTurnover { get; set; }
        public double? PayablesTurnover { get; set; }
        public double? InventoryTurnover { get; set; }
        public double? FixedAssetTurnover { get; set; }
        public double? AssetTurnover { get; set; }
        public double? OperatingCashFlowPerShare { get; set; }
        public double? FreeCashFlowPerShare { get; set; }
        public double? CashPerShare { get; set; }
        public double? PayoutRatio { get; set; }
        public double? OperatingCashFlowSalesRatio { get; set; }
        public double? FreeCashFlowOperatingCashFlowRatio { get; set; }
        public double? CashFlowCoverageRatios { get; set; }
        public double? ShortTermCoverageRatios { get; set; }
        public double? CapitalExpenditureCoverageRatio { get; set; }
        public double? DividendPaidAndCapexCoverageRatio { get; set; }
        public double? DividendPayoutRatio { get; set; }
        public double? PriceBookValueRatio { get; set; }
        public double? PriceToBookRatio { get; set; }

        public double? dividendYield { get; set; }
        public double? enterpriseValueMultiple { get; set; }
        public double? priceFairValue { get; set; }

        [Required]
        public DateTime dtExecuted { get; set; } = DateTime.Now;

        [Required]
        public int flag { get; set; } = 0;
    }
}
