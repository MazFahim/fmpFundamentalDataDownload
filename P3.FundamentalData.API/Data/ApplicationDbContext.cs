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
        public DbSet<DailyDCF> Temp_CompaniesDailyDiscountedCashFlow { get; set; }
        public DbSet<CompaniesDiscountedCashFlow> Temp_CompaniesDiscountedCashFlow { get; set; }
        public DbSet<AdvancedDiscountedCashFlowProjectionIncludingWACC> Temp_AdvancedDiscountedCashFlowProjectionIncludingWACC { get; set; }
        public DbSet<AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC> Temp_AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC { get; set; }
        //Institutional Stock Ownership
        public DbSet<InstitutionalStockOwnership> Temp_InstitutionalStockOwnership { get; set; }
        public DbSet<StockOwnershipByHolders> Temp_StockOwnershipByHolders { get; set; }
        public DbSet<InstitutionalHoldingsPortfolioPositionsSummary> Temp_InstitutionalHoldingsPortfolioPositionsSummary { get; set; }

        //ESG Score
        public DbSet<ESG_Score> Temp_EsgScoreForSymbol { get; set; }
        public DbSet<ESG_RiskRating> Temp_CompanyESGRiskRatings { get; set; }
        public DbSet<ESGBenchmarkingBySectorAndYear> Temp_ESGBenchmarkingBySectorAndYear { get; set; }

        //Price Target 
        public DbSet<PriceTargetsSummaryForSymbol> Temp_PriceTargetsSummaryForSymbol { get; set; }

        //Stock Look Up Tool
        public DbSet<StockScreener> Temp_StockScreener { get; set; }



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
    

