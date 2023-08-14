using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CashFLowStatement
    {
        [Key]
        [MaxLength(10)]
        public string SymName { get; set; }

        [Key]
        [Required]
        public DateTime DtDate { get; set; }

        [Key]
        [Required]
        [MaxLength(5)]
        public string CalendarYear { get; set; }

        [Key]
        [Required]
        [MaxLength(2)]
        public string Period { get; set; }

        public string ReportedCurrency { get; set; }
        public long? Cik { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public long? NetIncome { get; set; }
        public long? DepreciationAndAmortization { get; set; }
        public long? DeferredIncomeTax { get; set; }
        public long? StockBasedCompensation { get; set; }
        public long? ChangeInWorkingCapital { get; set; }
        public long? AccountsReceivables { get; set; }
        public long? Inventory { get; set; }
        public long? AccountsPayables { get; set; }
        public decimal? OtherWorkingCapital { get; set; }
        public long? OtherNonCashItems { get; set; }
        public decimal? NetCashProvidedByOperatingActivities { get; set; }
        public decimal? InvestmentsInPropertyPlantAndEquipment { get; set; }
        public decimal? AcquisitionsNet { get; set; }
        public decimal? PurchasesOfInvestments { get; set; }
        public decimal? SalesMaturitiesOfInvestments { get; set; }
        public long? OtherInvestingActivites { get; set; }
        public decimal? NetCashUsedForInvestingActivites { get; set; }
        public decimal? DebtRepayment { get; set; }
        public long? CommonStockIssued { get; set; }
        public long? CommonStockRepurchased { get; set; }
        public decimal? DividendsPaid { get; set; }
        public long? OtherFinancingActivites { get; set; }
        public decimal? NetCashUsedProvidedByFinancingActivities { get; set; }
        public long? EffectOfForexChangesOnCash { get; set; }
        public decimal? NetChangeInCash { get; set; }
        public decimal? CashAtEndOfPeriod { get; set; }
        public decimal? CashAtBeginningOfPeriod { get; set; }
        public decimal? OperatingCashFlow { get; set; }
        public decimal? CapitalExpenditure { get; set; }
        public decimal? FreeCashFlow { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
