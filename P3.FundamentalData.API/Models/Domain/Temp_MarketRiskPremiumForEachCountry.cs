namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_MarketRiskPremiumForEachCountry:TempBase
	{
		public string Country { get; set; }
		public string? Continent { get; set; }
		public double? TotalEquityRiskPremium { get; set; }
		public double? CountryRiskPremium { get; set; }
	}
}
