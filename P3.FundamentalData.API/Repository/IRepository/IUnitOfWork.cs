using P3.FundamentalData.API.Models;

namespace P3.FundamentalData.API.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<IncomeStatement> incomeStatementData { get; }
        IGenericRepository<BalanceSheetStatement> balanceSheetStatementData { get; }
        IGenericRepository<CashFLowStatement> CashFLowStatementData { get; }
        Task SaveAsync();
    }
}
