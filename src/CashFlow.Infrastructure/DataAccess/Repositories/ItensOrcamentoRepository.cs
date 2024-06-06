using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Orcamentos;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ItensOrcamentoRepository : IItensOrcamentoRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ItensOrcamentoRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Create(ItemOrcamento request)
        {
            request.Id = new Guid();

            await _dbContext.ItensOrcamentos.AddAsync(request);

            return request.Id;
        }

        public async Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento)
        {
            return await _dbContext.ItensOrcamentos.AsNoTracking().Where(io => io.CodigoOrcamento == codigoOrcamento).ToListAsync();
        }

        public async Task SalvarItensValores(List<ItemOrcamentoValor> itens)
        {
            await _dbContext.ItensOrcamentoValores.AddRangeAsync(itens);
        }

        public async Task SalvarItensValores(ItemOrcamentoValor item)
        {
            item.Id = Guid.NewGuid();
            await _dbContext.ItensOrcamentoValores.AddAsync(item);
        }

        public async Task<List<ItemOrcamentoValor>> GetValoresItemOrcamento(Guid codigoItem)
        {
            return await _dbContext.ItensOrcamentoValores.AsNoTracking().Where(iov => iov.CodigoItemOrcamento == codigoItem).ToListAsync();
        }

        public async Task<ItemOrcamento?> GetItemOrcamentoEValores(Guid codigoItem)
        {
            var itens = await _dbContext.ItensOrcamentos.Where(io => io.Id == codigoItem).FirstOrDefaultAsync();

            return itens;
        }

        public async Task RemoveItemsParaInsercao(Guid codigoItem)
        {
            var valoresParaRemover = await _dbContext.ItensOrcamentoValores.Where(iol => iol.CodigoItemOrcamento == codigoItem).ToListAsync();
            
            _dbContext.ItensOrcamentoValores.RemoveRange(valoresParaRemover);
        }

        public void UpdateItemOrcamento(ItemOrcamento itemOrcamento)
        {
            _dbContext.ItensOrcamentos.Update(itemOrcamento);
        }
    }
}
