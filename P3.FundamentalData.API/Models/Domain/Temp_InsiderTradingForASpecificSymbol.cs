using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	//[PrimaryKey("Symbol", "FilingDate", "TransactionDate", "ReportingName", "SecuritiesTransacted")]
	public class Temp_InsiderTradingForASpecificSymbol:TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		public DateTime FilingDate { get; set; }
		public DateTime TransactionDate { get; set; }
		public string? ReportingCik { get; set; }
		public string? TransactionType { get; set; }
		public int? SecuritiesOwned { get; set; }
		public string? CompanyCik { get; set; }
		public string ReportingName { get; set; }
		public string? TypeOfOwner { get; set; }
		public string? AcquistionOrDisposition { get; set; }
		public string? FormType { get; set; }
		public int? SecuritiesTransacted { get; set; }
		public double? Price { get; set; }
		public string? SecurityName { get; set; }
		public string? Link { get; set; }
	}
}
