using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses
{
    public interface IExpensesService
    {
        Task<DashboardTotalResponse> GetTotalExpense(long id);
    }
}
