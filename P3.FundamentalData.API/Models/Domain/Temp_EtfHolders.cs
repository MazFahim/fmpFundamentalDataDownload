using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_EtfHolders:TempBase
	{
		[Column("SymName")]
		public string Asset { get; set; }
		public string ETFHolder {get;set; }
		public string? Name { get; set; }
		public string? IsIn { get; set; }
		public string? Cusip { get; set; }	
		public long? SharesNumber { get; set; }
		public float? WeightPercentage { get; set; }
		public double? MarketValue { get; set; }
		public DateTime? Updated { get; set; }
	}
}
