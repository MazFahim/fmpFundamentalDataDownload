using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class InstitutionalStockOwnership
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public long? Cik { get; set; }
        public long? InvestorsHolding { get; set; }
        public long? LastInvestorsHolding { get; set; }
        public long? InvestorsHoldingChange { get; set; }
        public long? NumberOf13Fshares { get; set; }
        public long? LastNumberOf13Fshares { get; set; }
        public long? NumberOf13FsharesChange { get; set; }
        public long? TotalInvested { get; set; }
        public long? LastTotalInvested { get; set; }
        public long? TotalInvestedChange { get; set; }
        public float? OwnershipPercent { get; set; }
        public float? LastOwnershipPercent { get; set; }
        public float? OwnershipPercentChange { get; set; }
        public long? NewPositions { get; set; }
        public long? LastNewPositions { get; set; }
        public long? NewPositionsChange { get; set; }
        public long? IncreasedPositions { get; set; }
        public long? LastIncreasedPositions { get; set; }
        public long? IncreasedPositionsChange { get; set; }
        public long? ClosedPositions { get; set; }
        public long? LastClosedPositions { get; set; }
        public long? ClosedPositionsChange { get; set; }
        public long? ReducedPositions { get; set; }
        public long? LastReducedPositions { get; set; }
        public long? ReducedPositionsChange { get; set; }
        public long? TotalCalls { get; set; }
        public long? LastTotalCalls { get; set; }
        public long? TotalCallsChange { get; set; }
        public long? TotalPuts { get; set; }
        public long? LastTotalPuts { get; set; }
        public long? TotalPutsChange { get; set; }
        public float? PutCallRatio { get; set; }
        public float? LastPutCallRatio { get; set; }
        public float? PutCallRatioChange { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
