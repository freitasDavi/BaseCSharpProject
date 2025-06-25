using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Orcamentos
{
    public interface IItensOrcamentoRepository
    {
        // Task<Guid> Create(ItemOrcamento request);
        Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento);
        // Task SalvarItensValores(List<Object> itens);
        // Task SalvarItensValores(Object itens);
        // Task<List<Object>> GetValoresItemOrcamento(Guid codigoItem);
        Task<ItemOrcamento?> GetItemOrcamentoEValores(Guid codigoItem);
        Task RemoveItemsParaInsercao(Guid codigoItem);
        void UpdateItemOrcamento(ItemOrcamento itemOrcamento);
    }
}
