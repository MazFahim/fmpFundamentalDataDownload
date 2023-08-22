using P3.FundamentalData.API.Controllers;
using P3.FundamentalData.API.Data;
using P3.FundamentalData.API.Models;
using P3.FundamentalData.API.Models.Domain;
using P3.FundamentalData.API.Repository.IRepository;

namespace P3.FundamentalData.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
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
        private GenericRepository<Temp_SenateTradesForSpecificSymbol> _temp_SenateTradesForSpecificSymbol;
        private GenericRepository<tblInsiderTradingTransactionType> _tblInsiderTradingTransactionType;
        private GenericRepository<Temp_InsiderTradingForASpecificSymbol> _temp_InsiderTradingForASpecificSymbol;
        private GenericRepository<Temp_StockGradeFromAnalysts> _temp_StockGradeFromAnalysts;
		
		private GenericRepository<Temp_StockEarningsSurprisesForASymbol> _temp_StockEarningsSurprisesForASymbol;
		private GenericRepository<Temp_StockAnalystEstimate> _temp_StockAnalystEstimate;
        private GenericRepository<Temp_CompanyHistoricalMarketCapitalization> _temp_CompanyHistoricalMarketCapitalization;


		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

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
        public IGenericRepository<Temp_SenateTradesForSpecificSymbol> temp_SenateTradesForSpecificSymbol => _temp_SenateTradesForSpecificSymbol ??= new GenericRepository<Temp_SenateTradesForSpecificSymbol>(_context);
        public IGenericRepository<tblInsiderTradingTransactionType> tblInsiderTradingTransactionType => _tblInsiderTradingTransactionType ??= new GenericRepository<tblInsiderTradingTransactionType>(_context);
        public IGenericRepository<Temp_InsiderTradingForASpecificSymbol> temp_InsiderTradingForASpecificSymbol => _temp_InsiderTradingForASpecificSymbol ??= new GenericRepository<Temp_InsiderTradingForASpecificSymbol>(_context);
        public IGenericRepository<Temp_StockGradeFromAnalysts> temp_StockGradeFromAnalysts => _temp_StockGradeFromAnalysts ??= new GenericRepository<Temp_StockGradeFromAnalysts>(_context);
        public IGenericRepository<Temp_StockEarningsSurprisesForASymbol> temp_StockEarningsSurprisesForASymbol => _temp_StockEarningsSurprisesForASymbol ??= new GenericRepository<Temp_StockEarningsSurprisesForASymbol>(_context);
        public IGenericRepository<Temp_StockAnalystEstimate> temp_StockAnalystEstimate => _temp_StockAnalystEstimate ??= new GenericRepository<Temp_StockAnalystEstimate>(_context);
        public IGenericRepository<Temp_CompanyHistoricalMarketCapitalization> temp_CompanyHistoricalMarketCapitalization => _temp_CompanyHistoricalMarketCapitalization ??= new GenericRepository<Temp_CompanyHistoricalMarketCapitalization>(_context);


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
