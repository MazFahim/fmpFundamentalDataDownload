using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CashFLowStatement
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
        public string CalendarYear { get; set; }

        [Required]
        public string Period { get; set; }

        public string ReportedCurrency { get; set; }
        public string Cik { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        [Column(TypeName = "money")]
        public double? NetIncome { get; set; }
        [Column(TypeName = "money")]
        public double? DepreciationAndAmortization { get; set; }
        [Column(TypeName = "money")]
        public double? DeferredIncomeTax { get; set; }
        [Column(TypeName = "money")]
        public double? StockBasedCompensation { get; set; }
        [Column(TypeName = "money")]
        public double? ChangeInWorkingCapital { get; set; }
        [Column(TypeName = "money")]
        public double? AccountsReceivables { get; set; }
        [Column(TypeName = "money")]
        public double? Inventory { get; set; }
        [Column(TypeName = "money")]
        public double? AccountsPayables { get; set; }
        [Column(TypeName = "money")]
        public double? OtherWorkingCapital { get; set; }
        [Column(TypeName = "money")]
        public double? OtherNonCashItems { get; set; }
        [Column(TypeName = "money")]
        public double? NetCashProvidedByOperatingActivities { get; set; }
        [Column(TypeName = "money")]
        public double? InvestmentsInPropertyPlantAndEquipment { get; set; }
        [Column(TypeName = "money")]
        public double? AcquisitionsNet { get; set; }
        [Column(TypeName = "money")]
        public double? PurchasesOfInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? SalesMaturitiesOfInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? OtherInvestingActivites { get; set; }
        [Column(TypeName = "money")]
        public double? NetCashUsedForInvestingActivites { get; set; }
        [Column(TypeName = "money")]
        public double? DebtRepayment { get; set; }
        [Column(TypeName = "money")]
        public double? CommonStockIssued { get; set; }
        [Column(TypeName = "money")]
        public double? CommonStockRepurchased { get; set; }
        [Column(TypeName = "money")]
        public double? DividendsPaid { get; set; }
        [Column(TypeName = "money")]
        public double? OtherFinancingActivites { get; set; }
        [Column(TypeName = "money")]
        public double? NetCashUsedProvidedByFinancingActivities { get; set; }
        [Column(TypeName = "money")]
        public double? EffectOfForexChangesOnCash { get; set; }
        [Column(TypeName = "money")]
        public double? NetChangeInCash { get; set; }
        [Column(TypeName = "money")]
        public double? CashAtEndOfPeriod { get; set; }
        [Column(TypeName = "money")]
        public double? CashAtBeginningOfPeriod { get; set; }
        [Column(TypeName = "money")]
        public double? OperatingCashFlow { get; set; }
        [Column(TypeName = "money")]
        public double? CapitalExpenditure { get; set; }
        [Column(TypeName = "money")]
        public double? FreeCashFlow { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
