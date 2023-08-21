namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_ETFSectorWeightings:TempBase
	{
		public string IndexName { get; set; }
		public string Sector { get; set; }
		public string WeightPercentage { get; set; }

	}
}
