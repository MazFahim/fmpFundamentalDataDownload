using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_StockList : TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		public string? Name { get; set; }
		public double? Price { get; set; }
		public string? Exchange { get; set; }
		public string? ExchangeShortName { get; set; }
		public string? Type { get; set; }
		public string Remark { get; set; } = "List";
	}
}
