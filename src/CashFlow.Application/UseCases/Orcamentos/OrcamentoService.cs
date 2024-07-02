using CashFlow.Communication.Requests.Orcamento;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Orcamentos;
using CashFlow.Exception;
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
        public async Task<Guid> Create(CreateOrcamentoRequest request)
        {
            var orcamento = new Orcamento
            {
                CodigoCliente = request.CodigoCliente,
                Descricao = request.Descricao,
                Emissao = DateTime.Now,
                Validade = request.Validade,
                ValorTotal = 0
            };

            await _repository.Create(orcamento);
            await _unitOfWork.Commit();

            return orcamento.Id;
        }

        public async Task Update(Guid id, UpdateOrcamentoRequest request)
        {
            var orc = await _repository.GetById(id) ?? throw new NotFoundException(ResourceErrorMessages.ORCAMENTO_NOT_FOUND);

            orc.Descricao = request.Descricao;
            orc.Validade = request.Validade;
            if (request.ValorTotal != null)
                orc.ValorTotal = (decimal)request.ValorTotal;
            
            _repository.Update(orc);
            await _unitOfWork.Commit();
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
