using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Incomes;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class IncomesRepository : IIncomesRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public IncomesRepository(CashFlowDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task Create(Income newIncome)
        {
            await _dbContext.Incomes.AddAsync(newIncome);
        }

        public async Task<List<Income>> GetAll(long userId)
        {
            return await _dbContext.Incomes.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<decimal> GetTotalIncomes(long userId)
        {
            return await _dbContext.Incomes.AsNoTracking().Where(p => p.UserId == userId).SumAsync(i => i.Amount);
        }
    }
}
