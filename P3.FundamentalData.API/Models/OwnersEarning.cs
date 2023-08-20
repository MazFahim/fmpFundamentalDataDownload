using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class OwnersEarning
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public double? AveragePPE { get; set; }
        public long? MaintenanceCapex { get; set; }
        public double? OwnersEarnings { get; set; }
        public long? GrowthCapex { get; set; }
        public double? OwnersEarningsPerShare { get; set; }
        public DateTime DtExecuted { get; set; }
        public int Flag { get; set; }
    }
}
