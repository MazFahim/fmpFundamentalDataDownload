using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	[PrimaryKey("Id")]
	public class temp_secfilings

	{
		public Guid Id { get; set; }= Guid.NewGuid();
		[Column("symName")]
		public string symbol { get; set; }
		[Column("fillingDate")]
		public DateTime? FillingDate { get; set; }
		[Column("acceptedDate")]
		public DateTime? AcceptedDate { get; set; }
		[Column("link")]
		public string Link { get; set; }
		[Column("cik")]
		public string Cik { get; set; }
		[Column("type")]
		public string Type { get; set; }
		[Column("finalLink")]
		public string FinalLink { get; set; }
		[Column("dtExecuted", TypeName = "smalldatetime")]
		public DateTime? DtExecuted { get; set; } = DateTime.Today.Date;
		[Column("flag")]
		public int Flag { get; set; } = 0;
	}
}
