using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class UnityOfWork : IUnitOfWork
    {
        private readonly CashFlowDbContext _dbContext;
        private IDbContextTransaction? _transaction;
        public UnityOfWork(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public async Task Commit()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }
    }
}
