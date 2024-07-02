using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CashFlowDbContext _context;
        public UserRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task Create(User request)
        {
            await _context.Users.AddAsync(request);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
