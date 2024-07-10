using CashFlow.Communication.Requests.Incomes;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Incomes
{
    public interface IIncomesService
    {
        Task<Guid> CreateIncome(CreateIncomeRequest request);
        Task<List<Income>> GetAll(long id);
        Task<DashboardTotalResponse> GetTotalIncomes (long id);
    }
}
