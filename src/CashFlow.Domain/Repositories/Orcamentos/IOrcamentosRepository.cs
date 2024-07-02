using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Orcamentos
{
    public interface IOrcamentosRepository
    {
        Task Create(Orcamento orcamento);
        void Update(Orcamento orcamento);
        Task<Orcamento?> GetById(Guid id);
        Task<List<Orcamento>> Get();
    }
}
