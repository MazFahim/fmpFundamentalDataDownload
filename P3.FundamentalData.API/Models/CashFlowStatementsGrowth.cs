using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CashFlowStatementsGrowth
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
        public decimal? GrowthNetIncome { get; set; }
        public decimal? GrowthDepreciationAndAmortization { get; set; }
        public decimal? GrowthDeferredIncomeTax { get; set; }
        public decimal? GrowthStockBasedCompensation { get; set; }
        public decimal? GrowthChangeInWorkingCapital { get; set; }
        public decimal? GrowthAccountsReceivables { get; set; }
        public decimal? GrowthInventory { get; set; }
        public decimal? GrowthAccountsPayables { get; set; }
        public decimal? GrowthOtherWorkingCapital { get; set; }
        public decimal? GrowthOtherNonCashItems { get; set; }
        public decimal? GrowthNetCashProvidedByOperatingActivites { get; set; }
        public decimal? GrowthInvestmentsInPropertyPlantAndEquipment { get; set; }
        public decimal? GrowthAcquisitionsNet { get; set; }
        public decimal? GrowthPurchasesOfInvestments { get; set; }
        public decimal? GrowthSalesMaturitiesOfInvestments { get; set; }
        public decimal? GrowthOtherInvestingActivites { get; set; }
        public decimal? GrowthNetCashUsedForInvestingActivites { get; set; }
        public decimal? GrowthDebtRepayment { get; set; }
        public decimal? GrowthCommonStockIssued { get; set; }
        public decimal? GrowthCommonStockRepurchased { get; set; }
        public decimal? GrowthDividendsPaid { get; set; }
        public decimal? GrowthOtherFinancingActivites { get; set; }
        public decimal? GrowthNetCashUsedProvidedByFinancingActivities { get; set; }
        public decimal? GrowthEffectOfForexChangesOnCash { get; set; }
        public decimal? GrowthNetChangeInCash { get; set; }
        public decimal? GrowthCashAtEndOfPeriod { get; set; }
        public decimal? GrowthCashAtBeginningOfPeriod { get; set; }
        public decimal? GrowthOperatingCashFlow { get; set; }
        public decimal? GrowthCapitalExpenditure { get; set; }
        public decimal? GrowthFreeCashFlow { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;

    }
}
