using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_CompanyHistoricalMarketCapitalization:TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		[Column("dtDate")]
		public DateTime Date { get; set; }
		public double marketCap { get; set; }
	}
}
