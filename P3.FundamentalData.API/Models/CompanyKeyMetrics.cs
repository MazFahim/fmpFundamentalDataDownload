using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CompanyKeyMetrics
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public string Period { get; set; }
        public decimal? RevenuePerShare { get; set; }
        public decimal? NetIncomePerShare { get; set; }
        public decimal? OperatingCashFlowPerShare { get; set; }
        public decimal? FreeCashFlowPerShare { get; set; }
        public decimal? CashPerShare { get; set; }
        public decimal? BookValuePerShare { get; set; }
        public decimal? TangibleBookValuePerShare { get; set; }
        public decimal? ShareholdersEquityPerShare { get; set; }
        public decimal? InterestDebtPerShare { get; set; }
        public decimal? MarketCap { get; set; }
        public decimal? EnterpriseValue { get; set; }
        public decimal? PeRatio { get; set; }
        public decimal? PriceToSalesRatio { get; set; }
        public decimal? PocfRatio { get; set; }
        public decimal? PfcfRatio { get; set; }
        public decimal? PbRatio { get; set; }
        public decimal? PtbRatio { get; set; }
        public decimal? EvToSales { get; set; }
        public decimal? EnterpriseValueOverEBITDA { get; set; }
        public decimal? EvToOperatingCashFlow { get; set; }
        public decimal? EvToFreeCashFlow { get; set; }
        public decimal? EarningsYield { get; set; }
        public decimal? FreeCashFlowYield { get; set; }
        public decimal? debtToEquity { get; set; }
        public decimal? debtToAssets { get; set; }
        public decimal? netDebtToEBITDA { get; set; }
        public decimal? currentRatio { get; set; }
        public decimal? interestCoverage { get; set; }
        public decimal? incomeQuality { get; set; }
        public decimal? dividendYield { get; set; }
        public decimal? payoutRatio { get; set; }
        public decimal? salesGeneralAndAdministrativeToRevenue { get; set; }
        public decimal? researchAndDdevelopementToRevenue { get; set; }
        public decimal? intangiblesToTotalAssets { get; set; }
        public decimal? capexToOperatingCashFlow { get; set; }
        public decimal? capexToRevenue { get; set; }
        public decimal? capexToDepreciation { get; set; }
        public decimal? stockBasedCompensationToRevenue { get; set; }
        public decimal? grahamNumber { get; set; }
        public decimal? roic { get; set; }
        public decimal? returnOnTangibleAssets { get; set; }
        public decimal? grahamNetNet { get; set; }
        public decimal? workingCapital { get; set; }
        public decimal? tangibleAssetValue { get; set; }
        public decimal? netCurrentAssetValue { get; set; }
        public decimal? investedCapital { get; set; }
        public decimal? averageReceivables { get; set; }
        public decimal? averagePayables { get; set; }
        public decimal? averageInventory { get; set; }
        public decimal? daysSalesOutstanding { get; set; }
        public decimal? daysPayablesOutstanding { get; set; }
        public decimal? daysOfInventoryOnHand { get; set; }
        public decimal? receivablesTurnover { get; set; }
        public decimal? payablesTurnover { get; set; }
        public decimal? inventoryTurnover { get; set; }
        public decimal? roe { get; set; }
        public decimal? capexPerShare { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
