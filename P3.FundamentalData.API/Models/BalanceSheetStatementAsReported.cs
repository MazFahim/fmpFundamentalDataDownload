using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class BalanceSheetStatementAsReported
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
        public string Period { get; set; }

        public double? LiabilitiesAndStockHoldersEquity { get; set; }
        public double? Liabilities { get; set; }
        public double? LiabilitiesCurrent { get; set; }
        public long? CommonStockSharesAuthorized { get; set; }
        public double? CashAndCashEquivalentsAtCarryingValue { get; set; }
        public double? RetainedEarningsAccumulatedDeficit { get; set; }
        public double? LiabilitiesNoncurrent { get; set; }
        public double? PropertyPlantAndEquipmentNet { get; set; }
        public double? CommonStocksIncludingAdditionalPaidInCapital { get; set; }
        public long? CommercialPaper { get; set; }
        public double? LongTermDebtCurrent { get; set; }
        public double? CommonStockSharesOutstanding { get; set; }
        public double? OtherLiabilitiesNoncurrent { get; set; }
        public double? OtherLiabilitiesCurrent { get; set; }
        public double? AssetsCurrent { get; set; }
        public double? LongTermDebtNoncurrent { get; set; }
        public double? IntangibleAssetsNetExcludingGoodWill { get; set; }
        public double? ContractWithCustomerLiabilityCurrent { get; set; }
        public double? NonTradeReceivablesCurrent { get; set; }
        public double? CommonStockSharesIssued { get; set; }
        public double? StockHoldersEquity { get; set; }
        public double? AccountsReceivableNetCurrent { get; set; }
        public double? AccountsPayableCurrent { get; set; }
        public double? Assets { get; set; }
        public double? MarketableSecuritiesCurrent { get; set; }
        public double? AssetsNonCurrent { get; set; }
        public double? GoodWill { get; set; }
        public double? OtherAssetsCurrent { get; set; }
        public double? OtherAssetsNonCurrent { get; set; }
        public double? AvailableForSaleSecuritiesNonCurrent { get; set; }
        public double? InventoryNet { get; set; }
        public double? MarketableSecuritiesNonCurrent { get; set; }
        public double? AccumulatedOtherComprehensiveIncomeLossNetOfTax { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
