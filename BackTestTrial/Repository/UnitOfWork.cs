using BackTestTrial.Data;
using BackTestTrial.IRepository;
using BackTestTrial.Models;

namespace BackTestTrial.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private GenericRepository<tblBacktestMain> _backtestMainData;
        private GenericRepository<tblBacktestSetting> _backSettingMainData;
        private GenericRepository<StrategyConfigure> _StrategyConfigureData;
        private GenericRepository<StrategyTemplate> _StrategyTemplateData;

		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<tblBacktestMain> backtestMainData => _backtestMainData ??= new GenericRepository<tblBacktestMain>(_context);
        public IGenericRepository<tblBacktestSetting> backtestSettingData => _backSettingMainData ??= new GenericRepository<tblBacktestSetting>(_context);
        public IGenericRepository<StrategyConfigure> StrategyConfigureData => _StrategyConfigureData ??= new GenericRepository<StrategyConfigure>(_context);
        public IGenericRepository<StrategyTemplate> StrategyTemplateData => _StrategyTemplateData ??= new GenericRepository<StrategyTemplate>(_context);



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
