using BC = BCrypt.Net.BCrypt;
using CashFlow.Domain.Security;

namespace CashFlow.Infrastructure.Security
{
    internal class Cryptography : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }
    }
}
