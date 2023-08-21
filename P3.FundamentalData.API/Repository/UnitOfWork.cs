using P3.FundamentalData.API.Controllers;
using P3.FundamentalData.API.Data;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //Stock Fundamentals
        private readonly ApplicationDbContext _context;

        private GenericRepository<IncomeStatement> _incomeStatementData;
        private GenericRepository<BalanceSheetStatement> _balanceSheetStatementData;
        private GenericRepository<CashFLowStatement> _CashFlowStatementData;
        private GenericRepository<IncomeStatementAsReported> _IncomeStatementAsReportedData;
        private GenericRepository<BalanceSheetStatementAsReported> _BalanceSheetAsReportedData;
        private GenericRepository<CashFlowStatementAsReported> _CashFlowStatementAsReportedData;
        private GenericRepository<FullFinancilalStatementAsReported> _FullFinancilalStatementAsReportedData;
        private GenericRepository<InternationalFilings> _InternationalFilingsData;
        private GenericRepository<SharesFloat> _SharesFloatData;        
        private GenericRepository<CompanyNotesDue> _CompanyNotesDueData;
        private GenericRepository<CompanyFinancialRatio> _CompanyFinancialRatioData;
        private GenericRepository<CompanyFinancialRatiosTTM> _CompanyFinancialRatiosTTMData;
        //Stock Fundamentals Analysis
        private GenericRepository<StockFInancialScores> _StockFInancialScoresData;
        private GenericRepository<OwnersEarning> _OwnersEarningData;
        private GenericRepository<CompanyEnterpriseValue> _CompanyEnterpriseValueData;
        private GenericRepository<IncomeStatementsGrowth> _IncomeStatementsGrowthData;
        private GenericRepository<BalanceSheetGrowth> _BalanceSheetGrowthData;
        private GenericRepository<CashFlowStatementsGrowth> _CashFlowStatementsGrowthData;
        private GenericRepository<CompanyKeyMetricsTTM> _CompanyKeyMetricsTTMData;
        private GenericRepository<CompanyKeyMetrics> _CompanyKeyMetricsData;
        private GenericRepository<CompanyFinancialStatementGrowth> _CompanyFinancialStatementGrowthData;
        private GenericRepository<HistoricalCompaniesRating> _HistoricalCompaniesRatingData;
        private GenericRepository<CompaniesHistoricalDiscountedCashFlow> _CompaniesHistoricalDiscountedCashFlowData;
        private GenericRepository<DailyDCF> _DailyDCFData;
        private GenericRepository<CompaniesDiscountedCashFlow> _CompaniesDiscountedCashFlowData;
        private GenericRepository<AdvancedDiscountedCashFlowProjectionIncludingWACC> _AdvancedDCFProjectionIncludingWACCData;
        private GenericRepository<AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC> _AdvancedLeveredDCFProjectionIncludingWACCData;
        //Institutional Stock Ownership
        private GenericRepository<InstitutionalStockOwnership> _InstitutionalStockOwnershipData;
        private GenericRepository<StockOwnershipByHolders> _StockOwnershipByHoldersData;
        private GenericRepository<InstitutionalHoldingsPortfolioPositionsSummary> _InstitutionalHoldingsPortfolioPositionsSummaryData;


        private GenericRepository<temp_secfilings> _temp_secfilings;
        private GenericRepository<MajorIndexes> _majorIndexes;
        private GenericRepository<CompanyListSP500> _listSandP;
        private GenericRepository<TempHistoricalSP500> _tempHistoricalSP500;
        private GenericRepository<Temp_BulkData> _temp_bulkdata;
        private GenericRepository<Temp_StockList> _Temp_StockLists;
        private GenericRepository<Temp_EtfHolders> _temp_etfHolders;
        private GenericRepository<Temp_InstitutionalHoldersOfACompanay> _temp_InstitutionalHoldersOfACompanay;
        private GenericRepository<Temp_MutualFundHoldersOfACompanay> _temp_MutualFundHoldersOfACompanay;
        private GenericRepository<Temp_ETFSectorWeightings> _temp_ETFSectorWeightings;
        private GenericRepository<Temp_ETFCountryWeightings> _temp_ETFCountryWeightings;
        private GenericRepository<Temp_ETFStockExposureList> _temp_ETFStockExposureList;
        private GenericRepository<Temp_MarketRiskPremiumForEachCountry> _temp_MarketRiskPremiumForEachCountry;
		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        //Stock Fundamentals
        public IGenericRepository<IncomeStatement> incomeStatementData => _incomeStatementData ??= new GenericRepository<IncomeStatement>(_context);
        public IGenericRepository<BalanceSheetStatement> balanceSheetStatementData => _balanceSheetStatementData ??= new GenericRepository<BalanceSheetStatement>(_context);
        public IGenericRepository<temp_secfilings> Temp_SecFilings => _temp_secfilings ??= new GenericRepository<temp_secfilings>(_context);

        public IGenericRepository<CashFLowStatement> CashFLowStatementData => _CashFlowStatementData ??= new GenericRepository<CashFLowStatement>(_context);
        public IGenericRepository<IncomeStatementAsReported> IncomeStatementAsReportedData => _IncomeStatementAsReportedData ??= new GenericRepository<IncomeStatementAsReported>(_context);
        public IGenericRepository<BalanceSheetStatementAsReported> BalanceSheetAsReportedData => _BalanceSheetAsReportedData ??= new GenericRepository<BalanceSheetStatementAsReported>(_context);
        public IGenericRepository<CashFlowStatementAsReported> CashFlowStatementAsReportedData => _CashFlowStatementAsReportedData ??= new GenericRepository<CashFlowStatementAsReported>(_context);
        public IGenericRepository<FullFinancilalStatementAsReported> FullFinancilalStatementAsReportedData => _FullFinancilalStatementAsReportedData ??= new GenericRepository<FullFinancilalStatementAsReported>(_context);
        public IGenericRepository<InternationalFilings> InternationalFilingsData => _InternationalFilingsData ??= new GenericRepository<InternationalFilings>(_context);
        public IGenericRepository<SharesFloat> SharesFloatData => _SharesFloatData ??= new GenericRepository<SharesFloat>(_context);
        public IGenericRepository<CompanyNotesDue> CompanyNotesDueData => _CompanyNotesDueData ??= new GenericRepository<CompanyNotesDue>(_context);
        public IGenericRepository<CompanyFinancialRatio> CompanyFinancialRatioData => _CompanyFinancialRatioData ??= new GenericRepository<CompanyFinancialRatio>(_context);
        public IGenericRepository<CompanyFinancialRatiosTTM> CompanyFinancialRatiosTTMData => _CompanyFinancialRatiosTTMData ??= new GenericRepository<CompanyFinancialRatiosTTM>(_context);
        //Stock Fundamentals Analysis
        public IGenericRepository<StockFInancialScores> StockFInancialScoresData => _StockFInancialScoresData ??= new GenericRepository<StockFInancialScores>(_context);
        public IGenericRepository<OwnersEarning> OwnersEarningData => _OwnersEarningData ??= new GenericRepository<OwnersEarning>(_context);
        public IGenericRepository<CompanyEnterpriseValue> CompanyEnterpriseValueData => _CompanyEnterpriseValueData ??= new GenericRepository<CompanyEnterpriseValue>(_context);
        public IGenericRepository<IncomeStatementsGrowth> IncomeStatementsGrowthData => _IncomeStatementsGrowthData ??= new GenericRepository<IncomeStatementsGrowth>(_context);
        public IGenericRepository<BalanceSheetGrowth> BalanceSheetGrowthData => _BalanceSheetGrowthData ??= new GenericRepository<BalanceSheetGrowth>(_context);
        public IGenericRepository<CashFlowStatementsGrowth> CashFlowStatementsGrowthData => _CashFlowStatementsGrowthData ??= new GenericRepository<CashFlowStatementsGrowth>(_context);
        public IGenericRepository<CompanyKeyMetricsTTM> CompanyKeyMetricsTTMData => _CompanyKeyMetricsTTMData ??= new GenericRepository<CompanyKeyMetricsTTM>(_context);
        public IGenericRepository<CompanyKeyMetrics> CompanyKeyMetricsData => _CompanyKeyMetricsData ??= new GenericRepository<CompanyKeyMetrics>(_context);
        public IGenericRepository<CompanyFinancialStatementGrowth> CompanyFinancialStatementGrowthData => _CompanyFinancialStatementGrowthData ??= new GenericRepository<CompanyFinancialStatementGrowth>(_context);
        public IGenericRepository<HistoricalCompaniesRating> HistoricalCompaniesRatingData => _HistoricalCompaniesRatingData ??= new GenericRepository<HistoricalCompaniesRating>(_context);
        public IGenericRepository<CompaniesHistoricalDiscountedCashFlow> CompaniesHistoricalDiscountedCashFlowData => _CompaniesHistoricalDiscountedCashFlowData ??= new GenericRepository<CompaniesHistoricalDiscountedCashFlow>(_context);
        public IGenericRepository<DailyDCF> DailyDCFData => _DailyDCFData ??= new GenericRepository<DailyDCF>(_context);
        public IGenericRepository<CompaniesDiscountedCashFlow> CompaniesDiscountedCashFlowData => _CompaniesDiscountedCashFlowData ??= new GenericRepository<CompaniesDiscountedCashFlow>(_context);
        public IGenericRepository<AdvancedDiscountedCashFlowProjectionIncludingWACC> AdvancedDCFProjectionIncludingWACCData => _AdvancedDCFProjectionIncludingWACCData ??= new GenericRepository<AdvancedDiscountedCashFlowProjectionIncludingWACC>(_context);
        public IGenericRepository<AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC> AdvancedLeveredDCFProjectionIncludingWACCData => _AdvancedLeveredDCFProjectionIncludingWACCData ??= new GenericRepository<AdvancedLeveredDiscountedCashFlowProjectionIncludingWACC>(_context);

        //Institutional Stock Ownership
        public IGenericRepository<InstitutionalStockOwnership> InstitutionalStockOwnershipData => _InstitutionalStockOwnershipData ??= new GenericRepository<InstitutionalStockOwnership>(_context);
        public IGenericRepository<StockOwnershipByHolders> StockOwnershipByHoldersData => _StockOwnershipByHoldersData ??= new GenericRepository<StockOwnershipByHolders>(_context);
        public IGenericRepository<InstitutionalHoldingsPortfolioPositionsSummary> InstitutionalHoldingsPortfolioPositionsSummaryData => _InstitutionalHoldingsPortfolioPositionsSummaryData ??= new GenericRepository<InstitutionalHoldingsPortfolioPositionsSummary>(_context);


        public IGenericRepository<MajorIndexes> majorIndexesData => _majorIndexes ??= new GenericRepository<MajorIndexes>(_context);
        public IGenericRepository<CompanyListSP500> temp_ListSandP => _listSandP ??= new GenericRepository<CompanyListSP500>(_context);
        public IGenericRepository<TempHistoricalSP500> temp_HistoricalSP500 => _tempHistoricalSP500 ??= new GenericRepository<TempHistoricalSP500>(_context);
		public IGenericRepository<Temp_BulkData> temp_BulkData => _temp_bulkdata ??= new GenericRepository<Temp_BulkData>(_context);  
        public IGenericRepository<Temp_StockList> temp_StockList => _Temp_StockLists ??= new GenericRepository<Temp_StockList>(_context);  
        public IGenericRepository<Temp_EtfHolders> temp_EtfHolders => _temp_etfHolders ??= new GenericRepository<Temp_EtfHolders>(_context);
        public IGenericRepository<Temp_InstitutionalHoldersOfACompanay> temp_InstitutionalHoldersOfACompanay => _temp_InstitutionalHoldersOfACompanay ??= new GenericRepository<Temp_InstitutionalHoldersOfACompanay>(_context);
        public IGenericRepository<Temp_MutualFundHoldersOfACompanay> temp_MutualFundHoldersOfACompanay => _temp_MutualFundHoldersOfACompanay ??= new GenericRepository<Temp_MutualFundHoldersOfACompanay>(_context);
        public IGenericRepository<Temp_ETFSectorWeightings> temp_ETFSectorWeightings => _temp_ETFSectorWeightings ??= new GenericRepository<Temp_ETFSectorWeightings>(_context);
        public IGenericRepository<Temp_ETFCountryWeightings> temp_ETFCountryWeightings => _temp_ETFCountryWeightings ??= new GenericRepository<Temp_ETFCountryWeightings>(_context);
        public IGenericRepository<Temp_ETFStockExposureList> temp_ETFStockExposureList => _temp_ETFStockExposureList ??= new GenericRepository<Temp_ETFStockExposureList>(_context);
        public IGenericRepository<Temp_MarketRiskPremiumForEachCountry> temp_MarketRiskPremiumForEachCountry => _temp_MarketRiskPremiumForEachCountry ??= new GenericRepository<Temp_MarketRiskPremiumForEachCountry>(_context);

		public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
