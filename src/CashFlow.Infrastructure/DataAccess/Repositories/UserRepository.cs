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

        public async Task Delete(User user)
        {
            var userToRemove = await _context.Users.FindAsync(user.Id);
            _context.Users.Remove(userToRemove!);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(long id)
        {
            return await _context.Users.FirstAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByIdentifier(Guid identifier)
        {
            return await _context.Users.AsNoTracking().Where(u => u.UserIdentifier == identifier).FirstOrDefaultAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
