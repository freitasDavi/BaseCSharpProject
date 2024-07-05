using AutoMapper;
using CashFlow.Communication.Requests.Incomes;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Incomes;

namespace CashFlow.Application.UseCases.Incomes
{
    public class IncomesService : IIncomesService
    {
        private readonly IIncomesRepository _incomesRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IncomesService(IIncomesRepository incomesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _incomesRepository = incomesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateIncome(CreateIncomeRequest request)
        {
            var newIncome = _mapper.Map<Income>(request);

            await _incomesRepository.Create(newIncome);
            await _unitOfWork.Commit();

            return newIncome.Id;
        }

        public async Task<List<Income>> GetAll(long userId)
        {
            var incomes = await _incomesRepository.GetAll(userId);

            return incomes;
        }
    }
}
