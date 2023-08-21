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
        //Stock Fundamentals
        public DbSet<IncomeStatement> Temp_IncomeStatement { get; set; }
        public DbSet<BalanceSheetStatement> Temp_BalanceSheetStatement { get; set; }
        public DbSet<temp_secfilings> Temp_SecFilings { get; set; }

        public DbSet<CashFLowStatement> Temp_CashFlowStatement { get; set; }
        public DbSet<IncomeStatementAsReported> Temp_IncomeStatementsAsReported { get; set; }
        public DbSet<BalanceSheetStatementAsReported> Temp_BalanceSheetStatementsAsReported { get; set; }
        public DbSet<CashFlowStatementAsReported> Temp_CashFlowStatementAsReported { get; set; }
        public DbSet<FullFinancilalStatementAsReported> Temp_FullFinancialStatement { get; set; }
        public DbSet<InternationalFilings> Temp_InternationalFilings { get; set; }
        public DbSet<SharesFloat> Temp_SharesFloat { get; set; }
        public DbSet<CompanyNotesDue> Temp_CompanyNotesDue { get; set; }
        public DbSet<CompanyFinancialRatio> Temp_CompanyFinancialRatios { get; set; }
        public DbSet<CompanyFinancialRatiosTTM> Temp_CompanyFinancialRatiosTTM { get; set; }

        //Stock Fundamentals Analysis
        public DbSet<StockFInancialScores> Temp_StockFinancialScores { get; set; }
        public DbSet<OwnersEarning> Temp_OwnerEarnings{ get; set; }
        public DbSet<CompanyEnterpriseValue> Temp_CompanyEnterpriseValue { get; set; }
        public DbSet<IncomeStatementsGrowth> Temp_IncomeStatementsGrowth { get; set; }
        public DbSet<BalanceSheetGrowth> Temp_BalanceSheetGrowth { get; set; }
        public DbSet<CashFlowStatementsGrowth> Temp_CashFlowStatementsGrowth { get; set; }
        public DbSet<CompanyKeyMetricsTTM> Temp_CompanyKeyMetricsTTM { get; set; }
        public DbSet<CompanyKeyMetrics> Temp_CompanyKeyMetrics { get; set; }
        public DbSet<CompanyFinancialStatementGrowth> Temp_CompanyFinancialStatementGrowth { get; set; }
        public DbSet<HistoricalCompaniesRating> Temp_HistoricalCompaniesRating { get; set; }
        public DbSet<CompaniesHistoricalDiscountedCashFlow> Temp_CompaniesHistoricalDiscountedCashFlow { get; set; }

   

        public DbSet<MajorIndexes> Temp_MajorIndexes { get; set; }
        public DbSet<CompanyListSP500> Temp_CompanyListSP500 { get; set; }
        public DbSet<TempHistoricalSP500> Temp_HistoricalSP500 { get; set; }
        public DbSet<Temp_BulkData> Temp_BulkData { get; set; }
	}
       
}
    

