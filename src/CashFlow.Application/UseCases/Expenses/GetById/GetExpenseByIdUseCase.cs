﻿using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.GetById
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        private readonly IExpensesReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();

            var result = await _repository.GetById(loggedUser, id);

            if (result is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
