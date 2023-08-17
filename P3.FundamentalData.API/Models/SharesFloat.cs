using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class SharesFloat
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public float? FreeFloat { get; set; }

        public float? FloatShares { get; set; }

        public float? OutstandingShares { get; set; }

        [StringLength(255)]
        public string Source { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;

        [Required]
        public int Flag { get; set; } = 0;
    }
}
