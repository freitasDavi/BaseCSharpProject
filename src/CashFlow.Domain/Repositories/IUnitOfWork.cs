namespace CashFlow.Domain.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task Commit(); 
    }
}
