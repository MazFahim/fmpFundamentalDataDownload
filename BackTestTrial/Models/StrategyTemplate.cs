using System.ComponentModel.DataAnnotations;

namespace BackTestTrial.Models
{
	public class StrategyTemplate
	{
		public long TempId { get; set; }
		public string Strategy { get; set; }
		public byte Long { get; set; }
		public byte Short { get; set; }
		public float StopLoss { get; set; }
		public int ConfigId { get; set; }
	}
}
