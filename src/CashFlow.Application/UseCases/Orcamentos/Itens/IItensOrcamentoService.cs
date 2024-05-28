using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Orcamentos.Itens
{
    public interface IItensOrcamentoService
    {
        Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento);
        Task<Guid> Create(ItemOrcamento request);
    }
}
