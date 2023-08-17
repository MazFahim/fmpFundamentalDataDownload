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
        private GenericRepository<temp_secfilings> _temp_secfilings;

		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<IncomeStatement> incomeStatementData => _incomeStatementData ??= new GenericRepository<IncomeStatement>(_context);
        public IGenericRepository<BalanceSheetStatement> balanceSheetStatementData => _balanceSheetStatementData ??= new GenericRepository<BalanceSheetStatement>(_context);
        public IGenericRepository<temp_secfilings> Temp_SecFilings => _temp_secfilings ??= new GenericRepository<temp_secfilings>(_context);

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
