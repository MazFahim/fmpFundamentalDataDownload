using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_SenateTradesForSpecificSymbol:TempBase
	{
		public string SymName { get; set; }
		public string Link { get; set; }
		[Column(TypeName ="smalldatetime")]
		public DateTime DateRecieved { get; set; }
		[Column(TypeName = "smalldatetime")]
		public DateTime TransactionDate { get; set; }
		public string Type { get; set; }
		public string Amount { get; set; }
		public string Owner { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Comment { get; set; }
		public string? Office { get; set; }
		public string? AssetDescription { get; set; }
		public string? AssetType { get; set; }
	}
}
