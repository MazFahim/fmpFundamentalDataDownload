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

		Task SaveAsync();
    }
}
