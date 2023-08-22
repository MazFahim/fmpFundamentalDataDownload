using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_StockAnalystEstimate:TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		[Column("dtDate")]
		public DateTime Date { get; set; }
		public string Period { get; set; } = "Annual";
		public double EstimatedRevenueLow { get; set; }
		public double EstimatedRevenueHigh { get; set; }
		public double EstimatedRevenueAvg { get; set; }
		public double EstimatedEbitdaLow { get; set; }
		public double EstimatedEbitdaHigh { get; set; }
		public double EstimatedEbitdaAvg { get; set; }
		public double EstimatedEbitLow { get; set; }
		public double EstimatedEbitHigh { get; set; }
		public double EstimatedEbitAvg { get; set; }
		public double EstimatedNetIncomeLow { get; set; }
		public double EstimatedNetIncomeHigh { get; set; }
		public double EstimatedNetIncomeAvg { get; set; }
		public double EstimatedSgaExpenseLow { get; set; }
		public double EstimatedSgaExpenseHigh { get; set; }
		public double EstimatedSgaExpenseAvg { get; set; }
		public double EstimatedEpsAvg { get; set; }
		public double EstimatedEpsHigh { get; set; }
		public double EstimatedEpsLow { get; set; }
		public int NumberAnalystEstimatedRevenue { get; set; }
		public int NumberAnalystsEstimatedEps { get; set; }
	}
}
