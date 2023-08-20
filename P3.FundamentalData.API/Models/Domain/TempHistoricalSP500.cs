using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class TempHistoricalSP500 : TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		public DateTime dateAdded { get; set; }
		public string addedSecurity { get; set; }
		public string removedTicker { get; set; }
		public string removedSecurity { get; set; }
		[Column(TypeName ="smalldatetime")]
		public DateTime date { get; set; }

		public string reason { get; set; }
		
	}
}
