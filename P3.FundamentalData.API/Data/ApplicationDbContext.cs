using Microsoft.EntityFrameworkCore;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;

namespace P3.FundamentalData.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<IncomeStatement> Temp_IncomeStatement { get; set; }
        public DbSet<BalanceSheetStatement> Temp_BalanceSheetStatement { get; set; }
        public DbSet<temp_secfilings> Temp_SecFilings { get; set; }

	}
}
