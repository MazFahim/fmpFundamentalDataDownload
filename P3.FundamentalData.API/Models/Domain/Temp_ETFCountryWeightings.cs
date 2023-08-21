namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_ETFCountryWeightings:TempBase
	{
		public string IndexName { get; set; }
		public string Country { get;set; }
		public string weightPercentage { get; set; }
	}
}
