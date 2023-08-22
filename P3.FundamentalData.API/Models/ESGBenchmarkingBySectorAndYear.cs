using System.ComponentModel.DataAnnotations;

namespace P3.FundamentalData.API.Models
{
    public class ESGBenchmarkingBySectorAndYear
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Year { get; set; }
        public string Sector { get; set; }
        public float? EnvironmentalScore { get; set; }
        public float? SocialScore { get; set; }
        public float? GovernanceScore { get; set; }
        public float? ESGScore { get; set; }
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
