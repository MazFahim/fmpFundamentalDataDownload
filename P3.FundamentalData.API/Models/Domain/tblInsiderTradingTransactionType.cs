using Microsoft.EntityFrameworkCore;

namespace P3.FundamentalData.API.Models.Domain
{
	[PrimaryKey("Type","Source")]
	public class tblInsiderTradingTransactionType
	{
		public string Source { get; set; }
		public string Type { get; set; }
	}
}
