using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Orcamentos
{
    public interface IItensOrcamentoRepository
    {
        Task<Guid> Create(ItemOrcamento request);
        Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento);
        Task SalvarItensValores(List<ItemOrcamentoValor> itens);
        Task SalvarItensValores(ItemOrcamentoValor itens);
    }
}
