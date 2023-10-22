using BackTestTrial.Models;

namespace BackTestTrial.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //Stock Fundamental 
        IGenericRepository<tblBacktestMain> backtestMainData { get; }
        IGenericRepository<tblBacktestSetting> backtestSettingData { get; }
        IGenericRepository<StrategyConfigure> StrategyConfigureData { get; }
        IGenericRepository<StrategyTemplate> StrategyTemplateData { get; }
        
		Task SaveAsync();
    }
}
