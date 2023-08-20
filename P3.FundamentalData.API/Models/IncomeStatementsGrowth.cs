using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class IncomeStatementsGrowth
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
        public double? GrowthRevenue { get; set; }
        public double? GrowthCostOfRevenue { get; set; }
        public double? GrowthGrossProfit { get; set; }
        public double? GrowthGrossProfitRatio { get; set; }
        public double? GrowthResearchAndDevelopmentExpenses { get; set; }
        public double? GrowthGeneralAndAdministrativeExpenses { get; set; }
        public double? GrowthSellingAndMarketingExpenses { get; set; }
        public double? GrowthOtherExpenses { get; set; }
        public double? GrowthOperatingExpenses { get; set; }
        public double? GrowthCostAndExpenses { get; set; }
        public double? GrowthInterestExpense { get; set; }
        public double? GrowthDepreciationAndAmortization { get; set; }
        public double? GrowthEBITDA { get; set; }
        public double? GrowthEBITDARatio { get; set; }
        public double? GrowthOperatingIncome { get; set; }
        public double? GrowthOperatingIncomeRatio { get; set; }
        public double? GrowthTotalOtherIncomeExpensesNet { get; set; }
        public double? GrowthIncomeBeforeTax { get; set; }
        public double? GrowthIncomeBeforeTaxRatio { get; set; }
        public double? GrowthIncomeTaxExpense { get; set; }
        public double? GrowthNetIncome { get; set; }
        public double? GrowthNetIncomeRatio { get; set; }
        public double? GrowthEPS { get; set; }
        public double? GrowthEPSDiluted { get; set; }
        public double? GrowthWeightedAverageShsOut { get; set; }
        public double? GrowthWeightedAverageShsOutDil { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
