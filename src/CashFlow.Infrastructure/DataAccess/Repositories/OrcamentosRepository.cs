using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Orcamentos;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class OrcamentosRepository : IOrcamentosRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public OrcamentosRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Orcamento orcamento)
        {
            orcamento.Id = Guid.NewGuid();
            await _dbContext.Orcamentos.AddAsync(orcamento);
        }

        public async Task<Orcamento?> GetById(Guid id)
        {
            return await _dbContext.Orcamentos.AsNoTracking().Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Orcamento>> Get()
        {
            return await _dbContext.Orcamentos.AsNoTracking().ToListAsync();
        }
    }
}
