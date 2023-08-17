using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class CompanyFinancialRatiosTTM
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public double? DividendYielTTM { get; set; }
        public double? DividendYielPercentageTTM { get; set; }
        public double? PeRatioTTM { get; set; }
        public double? PegRatioTTM { get; set; }
        public double? PayoutRatioTTM { get; set; }
        public double? CurrentRatioTTM { get; set; }
        public double? QuickRatioTTM { get; set; }
        public double? CashRatioTTM { get; set; }
        public double? DaysOfSalesOutstandingTTM { get; set; }
        public double? DaysOfInventoryOutstandingTTM { get; set; }
        public double? OperatingCycleTTM { get; set; }
        public double? DaysOfPayablesOutstandingTTM { get; set; }
        public double? CashConversionCycleTTM { get; set; }
        public double? GrossProfitMarginTTM { get; set; }
        public double? OperatingProfitMarginTTM { get; set; }
        public double? PretaxProfitMarginTTM { get; set; }
        public double? NetProfitMarginTTM { get; set; }
        public double? EffectiveTaxRateTTM { get; set; }
        public double? ReturnOnAssetsTTM { get; set; }
        public double? ReturnOnEquityTTM { get; set; }
        public double? ReturnOnCapitalEmployedTTM { get; set; }
        public double? NetIncomePerEBTTTM { get; set; }
        public double? EbtPerEbitTTM { get; set; }
        public double? EbitPerRevenueTTM { get; set; }
        public double? DebtRatioTTM { get; set; }
        public double? DebtEquityRatioTTM { get; set; }
        public double? LongTermDebtToCapitalizationTTM { get; set; }
        public double? TotalDebtToCapitalizationTTM { get; set; }
        public double? InterestCoverageTTM { get; set; }
        public double? CashFlowToDebtRatioTTM { get; set; }
        public double? CompanyEquityMultiplierTTM { get; set; }
        public double? ReceivablesTurnoverTTM { get; set; }
        public double? PayablesTurnoverTTM { get; set; }
        public double? InventoryTurnoverTTM { get; set; }
        public double? FixedAssetTurnoverTTM { get; set; }
        public double? AssetTurnoverTTM { get; set; }
        public double? OperatingCashFlowPerShareTTM { get; set; }
        public double? FreeCashFlowPerShareTTM { get; set; }
        public double? CashPerShareTTM { get; set; }
        public double? OperatingCashFlowSalesRatioTTM { get; set; }
        public double? FreeCashFlowOperatingCashFlowRatioTTM { get; set; }
        public double? CashFlowCoverageRatiosTTM { get; set; }
        public double? ShortTermCoverageRatiosTTM { get; set; }
        public double? CapitalExpenditureCoverageRatioTTM { get; set; }
        public double? DividendPaidAndCapexCoverageRatioTTM { get; set; }
        public double? PriceBookValueRatioTTM { get; set; }
        public double? PriceToBookRatioTTM { get; set; }
        public double? PriceToSalesRatioTTM { get; set; }
        public double? PriceEarningsRatioTTM { get; set; }
        public double? PriceToFreeCashFlowsRatioTTM { get; set; }
        public double? PriceToOperatingCashFlowsRatioTTM { get; set; }
        public double? PriceCashFlowRatioTTM { get; set; }
        public double? PriceEarningsToGrowthRatioTTM { get; set; }
        public double? PriceSalesRatioTTM { get; set; }
        public double? EnterpriseValueMultipleTTM { get; set; }
        public double? PriceFairValueTTM { get; set; }
        public double? DividendPerShareTTM { get; set; }
        [Required]
        public DateTime dtExecuted { get; set; } = DateTime.Now;

        [Required]
        public int flag { get; set; } = 0;
    }
}
