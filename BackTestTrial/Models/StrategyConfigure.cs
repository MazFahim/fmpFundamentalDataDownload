using System.ComponentModel.DataAnnotations;

namespace BackTestTrial.Models
{
	public class StrategyConfigure
	{
		[Key]
		public int ConfigId { get; set; }

		[Required]
		[MaxLength(255)]
		public string Strategy { get; set; }

		[Required]
		public DateTime dtFrom { get; set; }

		[Required]
		public DateTime dtTo { get; set; }

		public decimal? LongLow { get; set; }

		public decimal? LongHigh { get; set; }

		public decimal? ShortLow { get; set; }

		public decimal? ShortHigh { get; set; }

		public decimal? StopLoss { get; set; }

		public int UserId { get; set; }

		public bool IsExecuted { get; set; }
	}
}
