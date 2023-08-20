using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class TempBase
	{
		public Guid Id { get; set; }= Guid.NewGuid();
		[Column(TypeName ="smalldatetime")]
		public DateTime dtExecuted { get; set; } = DateTime.Today.Date;
		public int flag { get; set; } = 0;
	}
}
