using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Orcamentos
{
    public interface IOrcamentoService
    {
        Task<Guid> Create(Orcamento request);
        Task<Orcamento> GetById(Guid id);
        Task<List<Orcamento>> GetAll();
    }
}
