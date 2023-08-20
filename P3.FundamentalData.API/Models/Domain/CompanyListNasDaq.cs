using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P3.FundamentalData.API.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class CompanyListNasDaq:TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		public string? Name { get; set; }
		public string? Sector { get; set; }
		public string? SubSector { get; set; }
		public string? HeadQuarter { get; set; }
		[Column(TypeName = "smalldatetime")]
		public DateTime? DateFirstAdded { get; set; }
		public string? Cik { get; set; }
		public string? Founded { get; set; }
	}
}
