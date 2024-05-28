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
    }
}
