using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class BalanceSheetGrowth
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
        public double? GrowthCashAndCashEquivalents { get; set; }
        public double? GrowthShortTermInvestments { get; set; }
        public double? GrowthCashAndShortTermInvestments { get; set; }
        public double? GrowthNetReceivables { get; set; }
        public double? GrowthInventory { get; set; }
        public double? GrowthOtherCurrentAssets { get; set; }
        public double? GrowthTotalCurrentAssets { get; set; }
        public double? GrowthPropertyPlantEquipmentNet { get; set; }
        public double? GrowthGoodwill { get; set; }
        public double? GrowthIntangibleAssets { get; set; }
        public double? GrowthGoodwillAndIntangibleAssets { get; set; }
        public double? GrowthLongTermInvestments { get; set; }
        public double? GrowthTaxAssets { get; set; }
        public double? GrowthOtherNonCurrentAssets { get; set; }
        public double? GrowthTotalNonCurrentAssets { get; set; }
        public double? GrowthOtherAssets { get; set; }
        public double? GrowthTotalAssets { get; set; }
        public double? GrowthAccountPayables { get; set; }
        public double? GrowthShortTermDebt { get; set; }
        public double? GrowthTaxPayables { get; set; }
        public double? GrowthDeferredRevenue { get; set; }
        public double? GrowthOtherCurrentLiabilities { get; set; }
        public double? GrowthTotalCurrentLiabilities { get; set; }
        public double? GrowthLongTermDebt { get; set; }
        public double? GrowthDeferredRevenueNonCurrent { get; set; }
        public double? GrowthDeferrredTaxLiabilitiesNonCurrent { get; set; }
        public double? GrowthOtherNonCurrentLiabilities { get; set; }
        public double? GrowthTotalNonCurrentLiabilities { get; set; }
        public double? GrowthOtherLiabilities { get; set; }
        public double? GrowthTotalLiabilities { get; set; }
        public double? GrowthCommonStock { get; set; }
        public double? GrowthRetainedEarnings { get; set; }
        public double? GrowthAccumulatedOtherComprehensiveIncomeLoss { get; set; }
        public double? GrowthOthertotalStockholdersEquity { get; set; }
        public double? GrowthTotalStockholdersEquity { get; set; }
        public double? GrowthTotalLiabilitiesAndStockholdersEquity { get; set; }
        public double? GrowthTotalInvestments { get; set; }
        public double? GrowthTotalDebt { get; set; }
        public double? GrowthNetDebt { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
