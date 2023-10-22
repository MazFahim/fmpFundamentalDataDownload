using System.ComponentModel.DataAnnotations;

namespace BackTestTrial.Models
{
	public class tblBacktestMain
	{
		[Key]
		public long BackId { get; set; }

		[Required]
		[MaxLength]
		public string Strategy { get; set; }

		[Required]
		public DateTime dtFrom { get; set; }

		[Required]
		public DateTime dtTo { get; set; }

		[Required]
		public bool IsExecuted { get; set; } = true;

		[Required]
		public DateTime dtExecute { get; set; }

		[Required]
		public Guid? UserGUID { get; set; }

		[MaxLength]
		public string? Symbols { get; set; }

		[MaxLength]
		public string Status { get; set; }

		[MaxLength]
		public string JobId { get; set; }

		[MaxLength]
		public string? BackName { get; set; }

		[Required]
		public bool IsPair { get; set; }

		[MaxLength]
		public string? SymbolsShort { get; set; }

		public long? TempId { get; set; }

		public int? orderTranId { get; set; }
	}
}
