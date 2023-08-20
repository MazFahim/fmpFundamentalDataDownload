using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class CompanyFinancialStatementGrowth
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public string Period { get; set; }
        public double? RevenueGrowth { get; set; }
        public double? GrossProfitGrowth { get; set; }
        public double? EbitGrowth { get; set; }
        public double? OperatingIncomeGrowth { get; set; }
        public double? NetIncomeGrowth { get; set; }
        public double? EpsGrowth { get; set; }
        public double? EpsDilutedGrowth { get; set; }
        public double? WeightedAverageSharesGrowth { get; set; }
        public double? WeightedAverageSharesDilutedGrowth { get; set; }
        public double? DividendsPerShareGrowth { get; set; }
        public double? OperatingCashFlowGrowth { get; set; }
        public double? FreeCashFlowGrowth { get; set; }
        public double? TenYRevenueGrowthPerShare { get; set; }
        public double? FiveYRevenueGrowthPerShare { get; set; }
        public double? ThreeYRevenueGrowthPerShare { get; set; }
        public double? TenYOperatingCFGrowthPerShare { get; set; }
        public double? FiveYOperatingCFGrowthPerShare { get; set; }
        public double? ThreeYOperatingCFGrowthPerShare { get; set; }
        public double? TenYNetIncomeGrowthPerShare { get; set; }
        public double? FiveYNetIncomeGrowthPerShare { get; set; }
        public double? ThreeYNetIncomeGrowthPerShare { get; set; }
        public double? TenYShareholdersEquityGrowthPerShare { get; set; }
        public double? FiveYShareholdersEquityGrowthPerShare { get; set; }
        public double? ThreeYShareholdersEquityGrowthPerShare { get; set; }
        public double? TenYDividendperShareGrowthPerShare { get; set; }
        public double? FiveYDividendperShareGrowthPerShare { get; set; }
        public double? ThreeYDividendperShareGrowthPerShare { get; set; }
        public double? ReceivablesGrowth { get; set; }
        public double? InventoryGrowth { get; set; }
        public double? AssetGrowth { get; set; }
        public double? BookValueperShareGrowth { get; set; }
        public double? DebtGrowth { get; set; }
        public double? RdExpenseGrowth { get; set; }
        public double? SgaExpensesGrowth { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
