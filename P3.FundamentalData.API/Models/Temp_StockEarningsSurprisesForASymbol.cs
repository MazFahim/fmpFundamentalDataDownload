using P3.FundamentalData.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
	public class Temp_StockEarningsSurprisesForASymbol:TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		[Column("dtDate")]
		public DateTime Date { get; set; }
		public double ActualEarningResult { get; set; }
		public double EstimatedEarning { get; set; }
	}
}
