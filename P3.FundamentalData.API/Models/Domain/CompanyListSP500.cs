using Newtonsoft.Json;
using P3.FundamentalData.API.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class CompanyListSP500
	{
		public Guid Id { get; set; }= Guid.NewGuid();
		[Column("SymName")]
		public string Symbol { get; set; }
		public string? Name { get; set; }
		public string? Sector { get; set; }
		public string? SubSector { get; set; }
		public string? HeadQuarter { get; set; }
		[JsonConverter(typeof(YearToDateConverter))]
		[Column(TypeName = "smalldatetime")]
		public DateTime? DateFirstAdded { get; set; }
		public string? Cik { get; set; }
		public string? Founded { get; set; }
		[Column(TypeName = "smalldatetime")]
		public DateTime dtExecuted { get; set; } = DateTime.Today.Date;
		public int flag { get; set; }= 0;
	}
}
