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
