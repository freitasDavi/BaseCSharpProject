
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        public DeleteExpenseUseCase(
            IExpensesReadOnlyRepository expensesRead,
            IExpensesWriteOnlyRepository repository,
            IUnitOfWork unitOfWork,
            ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;   
            _loggedUser = loggedUser;
            _readOnlyRepo = expensesRead;
        }

        private readonly IExpensesReadOnlyRepository _readOnlyRepo;
        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;

        public async Task Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            
            var expenses = await _readOnlyRepo.GetById(loggedUser, id);

            if (expenses is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _repository.Delete(id);

            await _unitOfWork.Commit();
        }
    }
}
