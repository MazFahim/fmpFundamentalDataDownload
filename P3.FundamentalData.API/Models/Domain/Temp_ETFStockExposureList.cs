using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_ETFStockExposureList:TempBase
	{
		
		public string etfSymbol { get; set; }
		[Column("SymName")]
		public string AssetExposure { get; set; }
		public double sharesNumber { get; set; }
		public double weightPercentage { get; set; }
		public double marketValue { get; set; }

	}
}
