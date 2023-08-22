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
		public DbSet<MajorIndexes> Temp_MajorIndexes { get; set; }
		public DbSet<CompanyListSP500> Temp_CompanyListSP500 { get; set; }
		public DbSet<TempHistoricalSP500> Temp_HistoricalSP500 { get; set; }
        public DbSet<Temp_BulkData> Temp_BulkData { get; set; }
        public DbSet<Temp_StockList>Temp_StockList { get; set; }
        public DbSet<Temp_EtfHolders> Temp_ETFHolders { get; set; }
		public DbSet<Temp_InstitutionalHoldersOfACompanay> Temp_InstitutionalHoldersOfACompanay { get; set; }
        public DbSet<Temp_MutualFundHoldersOfACompanay> Temp_MutualFundHoldersOfACompanay { get; set; }
        public DbSet<Temp_ETFSectorWeightings> Temp_ETFSectorWeightings { get; set; }
        public DbSet<Temp_ETFCountryWeightings> Temp_ETFCountryWeightings { get; set; }
        public DbSet<Temp_ETFStockExposureList> Temp_ETFStockExposureList { get; set; }
		public DbSet<Temp_MarketRiskPremiumForEachCountry> Temp_MarketRiskPremiumForEachCountry { get; set; }
		public DbSet<Temp_SenateTradesForSpecificSymbol> Temp_SenateTradesForSpecificSymbol { get; set; }
		public DbSet<tblInsiderTradingTransactionType> tblInsiderTradingTransactionType { get; set; }
		public DbSet<Temp_InsiderTradingForASpecificSymbol> Temp_InsiderTradingForASpecificSymbol { get; set; }
		public DbSet<Temp_StockGradeFromAnalysts> Temp_StockGradeFromAnalysts { get; set; }
        public DbSet<Temp_StockEarningsSurprisesForASymbol> Temp_StockEarningsSurprisesForASymbol { get; set; }
		public DbSet<Temp_StockAnalystEstimate> Temp_StockAnalystEstimate { get; set; }
        public DbSet<Temp_CompanyHistoricalMarketCapitalization> Temp_CompanyHistoricalMarketCapitalization { get; set; }
	}
       
}
    

