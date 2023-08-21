namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_InstitutionalHoldersOfACompanay:TempBase
	{
		public string SymName { get; set; }
		public string Holder { get; set; }
		public int ?Shares { get; set; }
		public DateTime? DateReported { get; set; }
		public double? Change { get; set; }
	}
}
