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
        public decimal? Revenue { get; set; }
        public decimal? CostOfRevenue { get; set; }
        public decimal? GrossProfit { get; set; }
        public double? GrossProfitRatio { get; set; }
        public decimal? ResearchAndDevelopmentExpenses { get; set; }
        public decimal? GeneralAndAdministrativeExpenses { get; set; }
        public decimal? SellingAndMarketingExpenses { get; set; }
        public decimal? SellingGeneralAndAdministrativeExpenses { get; set; }
        public decimal? OtherExpenses { get; set; }
        public decimal? OperatingExpenses { get; set; }
        public decimal? CostAndExpenses { get; set; }
        public decimal? BigInterestIncome { get; set; }
        public decimal? BigInterestExpense { get; set; }
        public decimal? DepreciationAndAmortization { get; set; }
        public decimal? Ebitda { get; set; }
        public double? EbitdaRatio { get; set; }
        public decimal? OperatingIncome { get; set; }
        public double? OperatingIncomeRatio { get; set; }
        public decimal? TotalOtherIncomeExpensesNet { get; set; }
        public decimal? IncomeBeforeTax { get; set; }
        public double? IncomeBeforeTaxRatio { get; set; }
        public decimal? IncomeTaxExpense { get; set; }
        public decimal? NetIncome { get; set; }
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