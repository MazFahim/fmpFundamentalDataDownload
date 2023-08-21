namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_MutualFundHoldersOfACompanay:TempBase
	{
		public string SymName { get; set; }
		public string Holder { get; set; }
		public double Shares { get; set; }
		public DateTime? DateReported { get; set; }
		public double? Change { get; set; }
		public double? WeightPercent { get; set; }
	}
}
