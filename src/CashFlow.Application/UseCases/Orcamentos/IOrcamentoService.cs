using CashFlow.Communication.Requests.Orcamento;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Orcamentos
{
    public interface IOrcamentoService
    {
        Task<Guid> Create(CreateOrcamentoRequest request);
        Task Update(Guid id, UpdateOrcamentoRequest request);
        Task<Orcamento> GetById(Guid id);
        Task<List<Orcamento>> GetAll();
    }
}
