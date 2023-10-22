using System.ComponentModel.DataAnnotations;

namespace BackTestTrial.Models
{
	public class tblBacktestSetting
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public long BackId { get; set; }

		public string SName { get; set; }

		public string SFlag { get; set; }

		[Required]
		public int SValue { get; set; }

		public string Remarks { get; set; }

		public string RemarksCaption { get; set; }
	}
}
