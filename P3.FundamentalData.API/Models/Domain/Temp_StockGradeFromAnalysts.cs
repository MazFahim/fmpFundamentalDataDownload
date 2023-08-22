using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models.Domain
{
	public class Temp_StockGradeFromAnalysts : TempBase
	{
		[Column("SymName")]
		public string Symbol { get; set; }
		[Column("dtDate")]
		public DateTime date { get; set; }
		public string GradingCompany { get; set; }
		public string PreviousGrade { get; set; }
		public string NewGrade { get; set; }
	}
}
