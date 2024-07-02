using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IUserRepository
    {
        Task Create(User request);
        Task<User?> GetByEmail(string email);
        Task<bool> ExistActiveUserWithEmail(string email);
    }
}
