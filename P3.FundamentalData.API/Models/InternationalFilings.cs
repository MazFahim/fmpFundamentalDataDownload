using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class InternationalFilings
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public int CalendarYear { get; set; }
        [Required]
        public string Period { get; set; }
        public string ReportedCurrency { get; set; }
        public string Cik { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public double? Revenue { get; set; }
        public double? CostOfRevenue { get; set; }
        public double? GrossProfit { get; set; }
        public double? GrossProfitRatio { get; set; }
        public double? ResearchAndDevelopmentExpenses { get; set; }
        public double? GeneralAndAdministrativeExpenses { get; set; }
        public double? SellingAndMarketingExpenses { get; set; }
        public double? SellingGeneralAndAdministrativeExpenses { get; set; }
        public double? OtherExpenses { get; set; }
        public double? OperatingExpenses { get; set; }
        public double? CostAndExpenses { get; set; }
        public double? InterestIncome { get; set; }
        public double? InterestExpense { get; set; }
        public long? DepreciationAndAmortization { get; set; }
        public long? Ebitda { get; set; }
        public double? Ebitdaratio { get; set; }
        public double? OperatingIncome { get; set; }
        public double? OperatingIncomeRatio { get; set; }
        public double? TotalOtherIncomeExpensesNet { get; set; }
        public double? IncomeBeforeTax { get; set; }
        public double? IncomeBeforeTaxRatio { get; set; }
        public double? IncomeTaxExpense { get; set; }
        public double? NetIncome { get; set; }
        public double? NetIncomeRatio { get; set; }
        public float? Eps { get; set; }
        public float? Epsdiluted { get; set; }
        public long? WeightedAverageShsOut { get; set; }
        public long? WeightedAverageShsOutDil { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
