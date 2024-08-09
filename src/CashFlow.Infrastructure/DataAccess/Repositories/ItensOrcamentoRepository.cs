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
            throw new NotImplementedException();
            //request.Id = new Guid();

            //await _dbContext.ItensOrcamentos.AddAsync(request);

            //return request.Id;
        }

        public async Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento)
        {
            throw new NotImplementedException();
            //return await _dbContext.ItensOrcamentos.AsNoTracking().Where(io => io.CodigoOrcamento == codigoOrcamento).ToListAsync();
        }

        public async Task SalvarItensValores(List<ItemOrcamentoValor> itens)
        {
            throw new NotImplementedException();
            //await _dbContext.ItensOrcamentoValores.AddRangeAsync(itens);
        }

        public async Task SalvarItensValores(ItemOrcamentoValor item)
        {
            item.Id = Guid.NewGuid();
            throw new NotImplementedException();
            //await _dbContext.ItensOrcamentoValores.AddAsync(item);
        }

        public async Task<List<ItemOrcamentoValor>> GetValoresItemOrcamento(Guid codigoItem)
        {
            throw new NotImplementedException();
            //return await _dbContext.ItensOrcamentoValores.AsNoTracking().Where(iov => iov.CodigoItemOrcamento == codigoItem).ToListAsync();
        }

        public async Task<ItemOrcamento?> GetItemOrcamentoEValores(Guid codigoItem)
        {
            //var itens = await _dbContext.ItensOrcamentos.Where(io => io.Id == codigoItem).FirstOrDefaultAsync();
            throw new NotImplementedException();
            //return itens;
        }

        public async Task RemoveItemsParaInsercao(Guid codigoItem)
        {
            throw new NotImplementedException();
            //var valoresParaRemover = await _dbContext.ItensOrcamentoValores.Where(iol => iol.CodigoItemOrcamento == codigoItem).ToListAsync();

            //_dbContext.ItensOrcamentoValores.RemoveRange(valoresParaRemover);
        }

        public void UpdateItemOrcamento(ItemOrcamento itemOrcamento)
        {
            throw new NotImplementedException();
            //_dbContext.ItensOrcamentos.Update(itemOrcamento);
        }
    }
}
