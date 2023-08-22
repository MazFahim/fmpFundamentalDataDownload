using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class ESG_Score
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public DateTime AcceptedDate { get; set; }
        public long? Cik { get; set; }
        public string CompanyName { get; set; }
        public string FormType { get; set; }
        public float? EnvironmentalScore { get; set; }
        public float? SocialScore { get; set; }
        public float? GovernanceScore { get; set; }
        public float? ESGScore { get; set; }
        public string Url { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
