using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Orcamentos;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Orcamentos
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentosRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public OrcamentoService(
            IOrcamentosRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Create(Orcamento request)
        {
            await _repository.Create(request);
            await _unitOfWork.Commit();

            return request.Id;
        }

        public async Task<List<Orcamento>> GetAll()
        {
            return await _repository.Get();
        }

        public async Task<Orcamento> GetById(Guid id)
        {
            var orc = await _repository.GetById(id);

            return orc is null ? throw new NotFoundException("Orçamento") : orc;
        }
    }
}
