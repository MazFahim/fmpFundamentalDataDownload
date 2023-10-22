using BackTestTrial.Models;
using Microsoft.EntityFrameworkCore;

namespace BackTestTrial.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<tblBacktestMain> tblBacktest_Main { get; set; }
		public DbSet<tblBacktestSetting> tblBacktest_Setting { get; set; }
		public DbSet<StrategyConfigure> tblStrategy_Configure { get; set; }
		public DbSet<StrategyTemplate> tblStrategy_Template { get; set; }

	}
}
