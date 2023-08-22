using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class StockScreener
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public long? MarketCap { get; set; }

        [Required]
        [StringLength(50)]
        public string Sector { get; set; }

        [StringLength(50)]
        public string Industry { get; set; }

        public float? Beta { get; set; }

        public double? Price { get; set; }

        public double? LastAnnualDividend { get; set; }

        public long? Volume { get; set; }

        [StringLength(100)]
        public string Exchange { get; set; }

        [Required]
        [StringLength(20)]
        public string ExchangeShortName { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        public bool? IsEtf { get; set; }

        public bool? IsActivelyTrading { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
