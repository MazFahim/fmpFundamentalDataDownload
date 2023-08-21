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


        // Major Indexes tables
        IGenericRepository<MajorIndexes> majorIndexesData { get; }
        IGenericRepository<CompanyListSP500> temp_ListSandP { get; }
        IGenericRepository<TempHistoricalSP500> temp_HistoricalSP500 { get; }
        // Bulk And Batch
        IGenericRepository<Temp_BulkData> temp_BulkData { get; }

        //Stock List
        IGenericRepository<Temp_StockList> temp_StockList { get; }
        Task SaveAsync();
    }
}
