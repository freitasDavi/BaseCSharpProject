using CashFlow.Communication.Resource;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses
{
    public class ExpensesServices : IExpensesService
    {
        private IExpensesReadOnlyRepository _expensesReadOnlyRepository;
        public ExpensesServices(IExpensesReadOnlyRepository expensesReadOnlyRepository)
        {
            _expensesReadOnlyRepository = expensesReadOnlyRepository;
        }
        public async Task<DashboardTotalResponse> GetTotalExpense(long id)
        {
            var total = await _expensesReadOnlyRepository.GetTotalExpenses(id);

            return new DashboardTotalResponse
            {
                Amount = total,
                Property = ResourceCommunicationMessages.EXPENSES_NAME,
            };
        }
    }
}
