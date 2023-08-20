using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.FundamentalData.API.Models
{
    public class CompanyNotesDue
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("SymName")]
        public string Symbol { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(15)]
        public string Cik { get; set; }

        [StringLength(20)]
        public string Exchange { get; set; }
        [Column("dtExecuted", TypeName = "smalldatetime")]
        public DateTime DtExecuted { get; set; } = DateTime.Now;

        [Required]
        public int Flag { get; set; } = 0;
    }
}
