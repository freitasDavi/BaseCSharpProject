using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {
        public GetAllExpensesUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IExpensesReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public async Task<ResponseExpensesJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map < List < ResponseShortExpenseJson >> (result)
            };
        }
    }
}
