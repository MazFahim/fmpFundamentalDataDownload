using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;

namespace P3.FundamentalData.API.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //Stock Fundamental 
        IGenericRepository<IncomeStatement> incomeStatementData { get; }
        IGenericRepository<BalanceSheetStatement> balanceSheetStatementData { get; }
        IGenericRepository<temp_secfilings> Temp_SecFilings { get; }
        IGenericRepository<CashFLowStatement> CashFLowStatementData { get; }
        IGenericRepository<IncomeStatementAsReported> IncomeStatementAsReportedData { get; }
        IGenericRepository<BalanceSheetStatementAsReported> BalanceSheetAsReportedData { get; }
        IGenericRepository<CashFlowStatementAsReported> CashFlowStatementAsReportedData { get; }
        IGenericRepository<FullFinancilalStatementAsReported> FullFinancilalStatementAsReportedData { get; }
        IGenericRepository<InternationalFilings> InternationalFilingsData { get; }

        IGenericRepository<SharesFloat> SharesFloatData { get; }
        IGenericRepository<CompanyNotesDue> CompanyNotesDueData { get; }
        IGenericRepository<CompanyFinancialRatio> CompanyFinancialRatioData { get; }
        IGenericRepository<CompanyFinancialRatiosTTM> CompanyFinancialRatiosTTMData { get; }

        //Stock Fundamental Analysis
        IGenericRepository<StockFInancialScores> StockFInancialScoresData { get; }
        IGenericRepository<OwnersEarning> OwnersEarningData { get; }
        IGenericRepository<CompanyEnterpriseValue> CompanyEnterpriseValueData { get; }
        IGenericRepository<IncomeStatementsGrowth> IncomeStatementsGrowthData { get; }
        IGenericRepository<BalanceSheetGrowth> BalanceSheetGrowthData { get; }
        IGenericRepository<CashFlowStatementsGrowth> CashFlowStatementsGrowthData { get; }
        IGenericRepository<CompanyKeyMetricsTTM> CompanyKeyMetricsTTMData { get; }
        IGenericRepository<CompanyKeyMetrics> CompanyKeyMetricsData { get; }
        IGenericRepository<CompanyFinancialStatementGrowth> CompanyFinancialStatementGrowthData { get; }
        IGenericRepository<HistoricalCompaniesRating> HistoricalCompaniesRatingData { get; }
        IGenericRepository<CompaniesHistoricalDiscountedCashFlow> CompaniesHistoricalDiscountedCashFlowData { get; }
        IGenericRepository<DailyDCF> DailyDCFData { get; }
        IGenericRepository<CompaniesDiscountedCashFlow> CompaniesDiscountedCashFlowData { get; }
        IGenericRepository<AdvancedDiscountedCashFlowProjectionIncludingWACC> AdvancedDCFProjectionIncludingWACCData { get; }
        IGenericRepository<AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC> AdvancedLeveredDCFProjectionIncludingWACCData { get; }

        //Institutional Stock Ownership
        IGenericRepository<InstitutionalStockOwnership> InstitutionalStockOwnershipData { get; }
        IGenericRepository<StockOwnershipByHolders> StockOwnershipByHoldersData { get; }
        IGenericRepository<InstitutionalHoldingsPortfolioPositionsSummary> InstitutionalHoldingsPortfolioPositionsSummaryData { get; }

        //ESG Score
        IGenericRepository<ESG_Score> ESG_ScoreData { get; }
        IGenericRepository<ESG_RiskRating> ESG_RiskRatingData { get; }
        IGenericRepository<ESGBenchmarkingBySectorAndYear> ESGBenchmarkingBySectorAndYearData { get; }
        //Price Target
        IGenericRepository<PriceTargetsSummaryForSymbol> PriceTargetsSummaryForSymbolData { get; }
        //Stock Look Up Tool
        IGenericRepository<StockScreener> StockScreenerData { get; }



        // Major Indexes tables
        IGenericRepository<MajorIndexes> majorIndexesData { get; }
        IGenericRepository<CompanyListSP500> temp_ListSandP { get; }
        IGenericRepository<TempHistoricalSP500> temp_HistoricalSP500 { get; }
        // Bulk And Batch
        IGenericRepository<Temp_BulkData> temp_BulkData { get; }

        //Stock List
        IGenericRepository<Temp_StockList> temp_StockList { get; }
        // Fund Holdings
        IGenericRepository<Temp_EtfHolders> temp_EtfHolders { get; }
        IGenericRepository<Temp_InstitutionalHoldersOfACompanay> temp_InstitutionalHoldersOfACompanay { get; }
        IGenericRepository<Temp_MutualFundHoldersOfACompanay> temp_MutualFundHoldersOfACompanay { get; }
        IGenericRepository<Temp_ETFSectorWeightings> temp_ETFSectorWeightings { get; }
        IGenericRepository<Temp_ETFCountryWeightings> temp_ETFCountryWeightings { get; }
        IGenericRepository<Temp_ETFStockExposureList> temp_ETFStockExposureList { get; }
        //Economics
        IGenericRepository<Temp_MarketRiskPremiumForEachCountry> temp_MarketRiskPremiumForEachCountry { get; }
        IGenericRepository<Temp_SenateTradesForSpecificSymbol> temp_SenateTradesForSpecificSymbol { get; }

        //Insider Trading
        IGenericRepository<tblInsiderTradingTransactionType> tblInsiderTradingTransactionType { get; }
        IGenericRepository<Temp_InsiderTradingForASpecificSymbol> temp_InsiderTradingForASpecificSymbol { get; }

        //Stock Statistics
        IGenericRepository<Temp_StockGradeFromAnalysts> temp_StockGradeFromAnalysts { get; }
        IGenericRepository<Temp_StockEarningsSurprisesForASymbol> temp_StockEarningsSurprisesForASymbol { get;}
        IGenericRepository<Temp_StockAnalystEstimate> temp_StockAnalystEstimate { get; }
        IGenericRepository<Temp_CompanyHistoricalMarketCapitalization> temp_CompanyHistoricalMarketCapitalization { get; }


		Task SaveAsync();
    }
}
