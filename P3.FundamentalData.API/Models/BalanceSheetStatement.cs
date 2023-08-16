using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class BalanceSheetStatement
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
        [Column(TypeName = "smallint")]
        public short CalendarYear { get; set; }
        [Required]
        [MaxLength(2)]
        public string Period { get; set; }
        [MaxLength(5)]
        public string ReportedCurrency { get; set; }
        [MaxLength(15)]
        public string Cik { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FillingDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? AcceptedDate { get; set; }
        [Column(TypeName = "money")]
        public double? CashAndCashEquivalents { get; set; }
        [Column(TypeName = "money")]
        public double? ShortTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? CashAndShortTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? NetReceivables { get; set; }
        [Column(TypeName = "money")]
        public double? Inventory { get; set; }
        [Column(TypeName = "money")]
        public double? OtherCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public double? TotalCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public double? PropertyPlantEquipmentNet { get; set; }
        [Column(TypeName = "money")]
        public double? Goodwill { get; set; }
        [Column(TypeName = "money")]
        public double? IntangibleAssets { get; set; }
        [Column(TypeName = "money")]
        public double? GoodwillAndIntangibleAssets { get; set; }
        [Column(TypeName = "money")]
        public double? LongTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? TaxAssets { get; set; }
        [Column(TypeName = "money")]
        public double? OtherNonCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public double? TotalNonCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public double? OtherAssets { get; set; }
        [Column(TypeName = "money")]
        public double? TotalAssets { get; set; }
        [Column(TypeName = "money")]
        public double? AccountPayables { get; set; }
        [Column(TypeName = "money")]
        public double? ShortTermDebt { get; set; }
        [Column(TypeName = "money")]
        public double? TaxPayables { get; set; }
        [Column(TypeName = "money")]
        public double? DeferredRevenue { get; set; }
        [Column(TypeName = "money")]
        public double? OtherCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? TotalCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? LongTermDebt { get; set; }
        [Column(TypeName = "money")]
        public double? DeferredRevenueNonCurrent { get; set; }
        [Column(TypeName = "money")]
        public double? DeferredTaxLiabilitiesNonCurrent { get; set; }
        [Column(TypeName = "money")]
        public double? OtherNonCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? TotalNonCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? OtherLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? CapitalLeaseObligations { get; set; }
        [Column(TypeName = "money")]
        public double? TotalLiabilities { get; set; }
        [Column(TypeName = "money")]
        public double? PreferredStock { get; set; }
        [Column(TypeName = "money")]
        public double? CommonStock { get; set; }
        [Column(TypeName = "money")]
        public double? RetainedEarnings { get; set; }
        [Column(TypeName = "money")]
        public double? AccumulatedOtherComprehensiveIncomeLoss { get; set; }
        [Column(TypeName = "money")]
        public double? OtherTotalStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public double? TotalStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public double? TotalEquity { get; set; }
        [Column(TypeName = "money")]
        public double? TotalLiabilitiesAndStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public double? MinorityInterest { get; set; }
        [Column(TypeName = "money")]
        public double? TotalLiabilitiesAndTotalEquity { get; set; }
        [Column(TypeName = "money")]
        public double? TotalInvestments { get; set; }
        [Column(TypeName = "money")]
        public double? TotalDebt { get; set; }
        [Column(TypeName = "money")]
        public double? NetDebt { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Link { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string FinalLink { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
