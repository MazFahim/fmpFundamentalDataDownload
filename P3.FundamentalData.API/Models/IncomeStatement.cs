using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class IncomeStatement
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate",TypeName ="smalldatetime")]
        public DateTime Date { get; set; }
        [Required]
        public int CalendarYear { get; set; }
        [Required]
        public string Period { get; set; }
        public string ReportedCurrency { get; set; }
        public string Cik { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        [Column(TypeName = "money")]
        public double? Revenue { get; set; }
        [Column(TypeName = "money")]
        public double? CostOfRevenue { get; set; }
        [Column(TypeName = "money")]
        public double? GrossProfit { get; set; }
        public double? GrossProfitRatio { get; set; }
        [Column(TypeName = "money")]
        public double? ResearchAndDevelopmentExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? GeneralAndAdministrativeExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? SellingAndMarketingExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? SellingGeneralAndAdministrativeExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? OtherExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? OperatingExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? CostAndExpenses { get; set; }
        [Column(TypeName = "money")]
        public double? BigInterestIncome { get; set; }
        [Column(TypeName = "money")]
        public double? BigInterestExpense { get; set; }
        [Column(TypeName = "money")]
        public double? DepreciationAndAmortization { get; set; }
        [Column(TypeName = "money")]
        public double? Ebitda { get; set; }
        public double? EbitdaRatio { get; set; }
        [Column(TypeName = "money")]
        public double? OperatingIncome { get; set; }
        public double? OperatingIncomeRatio { get; set; }
        [Column(TypeName = "money")]
        public double? TotalOtherIncomeExpensesNet { get; set; }
        [Column(TypeName = "money")]
        public double? IncomeBeforeTax { get; set; }
        public double? IncomeBeforeTaxRatio { get; set; }
        [Column(TypeName = "money")]
        public double? IncomeTaxExpense { get; set; }
        [Column(TypeName = "money")]
        public double? NetIncome { get; set; }
        public double? NetIncomeRatio { get; set; }
        public double? Eps { get; set; }
        public double? EpsDiluted { get; set; }
        public long? WeightedAverageShsOut { get; set; }
        public long? WeightedAverageShsOutDil { get; set; }
        public string? Link { get; set; }
        public string? FinalLink { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}