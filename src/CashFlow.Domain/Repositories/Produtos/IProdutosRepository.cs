

using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Produtos;

public interface IProdutosRepository
{
    Task<Guid> Create(Produto request);
    Task<List<Produto>> GetAll();
    Task<Produto> GetById(Guid id, bool asNoTracking = true);
    void Update(Produto request);
}