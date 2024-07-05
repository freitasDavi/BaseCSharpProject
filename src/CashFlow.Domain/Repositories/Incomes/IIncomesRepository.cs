using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Incomes
{
    public interface IIncomesRepository
    {
        Task Create(Income newIncome);
        Task<List<Income>> GetAll(long userId);
    }
}
