using P3.FundamentalData.API.Models;

namespace P3.FundamentalData.API.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //Stock Fundamental 
        IGenericRepository<IncomeStatement> incomeStatementData { get; }
        IGenericRepository<BalanceSheetStatement> balanceSheetStatementData { get; }
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

        Task SaveAsync();
    }
}
