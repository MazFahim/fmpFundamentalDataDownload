using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;

namespace P3.FundamentalData.API.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
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
        
        // Major Indexes tables
        IGenericRepository<MajorIndexes> majorIndexesData { get; }
        IGenericRepository<CompanyListSP500> temp_ListSandP { get; }
        IGenericRepository<TempHistoricalSP500> temp_HistoricalSP500 { get; }
        IGenericRepository<Temp_BulkData> temp_BulkData { get; }
        Task SaveAsync();
    }
}
