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

        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
