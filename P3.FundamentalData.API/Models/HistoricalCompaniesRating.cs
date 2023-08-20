using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class HistoricalCompaniesRating
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }
        [Required]
        [Column("dtDate", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public string Rating { get; set; }
        public int? RatingScore { get; set; }
        public string RatingRecommendation { get; set; }
        public int? RatingDetailsDCFScore { get; set; }
        public string RatingDetailsDCFRecommendation { get; set; }
        public int? RatingDetailsROEScore { get; set; }
        public string RatingDetailsROERecommendation { get; set; }
        public int? RatingDetailsROAScore { get; set; }
        public string RatingDetailsROARecommendation { get; set; }
        public int? RatingDetailsDEScore { get; set; }
        public string RatingDetailsDERecommendation { get; set; }
        public int? RatingDetailsPEScore { get; set; }
        public string RatingDetailsPERecommendation { get; set; }
        public int? RatingDetailsPBScore { get; set; }
        public string RatingDetailsPBRecommendation { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;
        public int Flag { get; set; } = 0;
    }
}
