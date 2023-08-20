using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CompanyKeyMetricsTTM
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        public float? RevenuePerShareTTM { get; set; }
        public float? NetIncomePerShareTTM { get; set; }
        public float? OperatingCashFlowPerShareTTM { get; set; }
        public float? FreeCashFlowPerShareTTM { get; set; }
        public float? CashPerShareTTM { get; set; }
        public float? BookValuePerShareTTM { get; set; }
        public float? TangibleBookValuePerShareTTM { get; set; }
        public float? ShareholdersEquityPerShareTTM { get; set; }
        public float? InterestDebtPerShareTTM { get; set; }
        public long? MarketCapTTM { get; set; }
        public long? EnterpriseValueTTM { get; set; }
        public float? PeRatioTTM { get; set; }
        public float? PriceToSalesRatioTTM { get; set; }
        public float? PocfratioTTM { get; set; }
        public float? PfcfRatioTTM { get; set; }
        public float? PbRatioTTM { get; set; }
        public float? PtbRatioTTM { get; set; }
        public float? EvToSalesTTM { get; set; }
        public float? EnterpriseValueOverEBITDATTM { get; set; }
        public float? EvToOperatingCashFlowTTM { get; set; }
        public float? EvToFreeCashFlowTTM { get; set; }
        public float? EarningsYieldTTM { get; set; }
        public float? FreeCashFlowYieldTTM { get; set; }
        public float? DebtToEquityTTM { get; set; }
        public float? DebtToAssetsTTM { get; set; }
        public float? NetDebtToEBITDATTM { get; set; }
        public float CurrentRatioTTM { get; set; }
        public float InterestCoverageTTM { get; set; }
        public float IncomeQualityTTM { get; set; }
        public float DividendYieldTTM { get; set; }
        public float DividendYieldPercentageTTM { get; set; }
        public float PayoutRatioTTM { get; set; }
        public float SalesGeneralAndAdministrativeToRevenueTTM { get; set; }
        public float? ResearchAndDevelopmentToRevenueTTM { get; set; }
        public float IntangiblesToTotalAssetsTTM { get; set; }
        public float CapexToOperatingCashFlowTTM { get; set; }
        public float CapexToRevenueTTM { get; set; }
        public float CapexToDepreciationTTM { get; set; }
        public float StockBasedCompensationToRevenueTTM { get; set; }
        public float GrahamNumberTTM { get; set; }
        public float RoicTTM { get; set; }
        public float ReturnOnTangibleAssetsTTM { get; set; }
        public float GrahamNetNetTTM { get; set; }
        public long WorkingCapitalTTM { get; set; }
        public long TangibleAssetValueTTM { get; set; }
        public long NetCurrentAssetValueTTM { get; set; }
        public float InvestedCapitalTTM { get; set; }
        public long AverageReceivablesTTM { get; set; }
        public long AveragePayablesTTM { get; set; }
        public long AverageInventoryTTM { get; set; }
        public float DaysSalesOutstandingTTM { get; set; }
        public float DaysPayablesOutstandingTTM { get; set; }
        public float DaysOfInventoryOnHandTTM { get; set; }
        public float ReceivablesTurnoverTTM { get; set; }
        public float PayablesTurnoverTTM { get; set; }
        public float InventoryTurnoverTTM { get; set; }
        public float RoeTTM { get; set; }
        public float CapexPerShareTTM { get; set; }
        public float DividendPerShareTTM { get; set; }
        public float DebtToMarketCapTTM { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
