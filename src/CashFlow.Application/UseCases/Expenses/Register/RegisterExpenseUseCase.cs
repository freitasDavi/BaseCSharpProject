using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository  _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;
        public RegisterExpenseUseCase(
            IExpensesWriteOnlyRepository expensesRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILoggedUser loggedUser)
        {
            _repository = expensesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }
        public async Task<ResponseRegisterExpenseJson> Execute (RequestExpenseJson request)
        {
            Validate(request);

            var loggedUser = await _loggedUser.Get();

            var entity = _mapper.Map<Expense>(request);
            entity.UserId = loggedUser.Id;

            await _repository.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisterExpenseJson>(entity);
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new ExpenseValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
