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
        public decimal? CashAndCashEquivalents { get; set; }
        [Column(TypeName = "money")]
        public decimal? ShortTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public decimal? CashAndShortTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public decimal? NetReceivables { get; set; }
        [Column(TypeName = "money")]
        public decimal? Inventory { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? PropertyPlantEquipmentNet { get; set; }
        [Column(TypeName = "money")]
        public decimal? Goodwill { get; set; }
        [Column(TypeName = "money")]
        public decimal? IntangibleAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? GoodwillAndIntangibleAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? LongTermInvestments { get; set; }
        [Column(TypeName = "money")]
        public decimal? TaxAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherNonCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalNonCurrentAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalAssets { get; set; }
        [Column(TypeName = "money")]
        public decimal? AccountPayables { get; set; }
        [Column(TypeName = "money")]
        public decimal? ShortTermDebt { get; set; }
        [Column(TypeName = "money")]
        public decimal? TaxPayables { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeferredRevenue { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? LongTermDebt { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeferredRevenueNonCurrent { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeferredTaxLiabilitiesNonCurrent { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherNonCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalNonCurrentLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? CapitalLeaseObligations { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalLiabilities { get; set; }
        [Column(TypeName = "money")]
        public decimal? PreferredStock { get; set; }
        [Column(TypeName = "money")]
        public decimal? CommonStock { get; set; }
        [Column(TypeName = "money")]
        public decimal? RetainedEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal? AccumulatedOtherComprehensiveIncomeLoss { get; set; }
        [Column(TypeName = "money")]
        public decimal? OtherTotalStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalEquity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalLiabilitiesAndStockholdersEquity { get; set; }
        [Column(TypeName = "money")]
        public decimal? MinorityInterest { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalLiabilitiesAndTotalEquity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalInvestments { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalDebt { get; set; }
        [Column(TypeName = "money")]
        public decimal? NetDebt { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Link { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string FinalLink { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
