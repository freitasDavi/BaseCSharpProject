namespace CashFlow.Application.UseCases.Users
{
    public static class PasswordService
    {
        public static string HashPassword(string password)
        {
            return BC.EnhancedHashPassword(password, 13);
        }

        public static bool VerifyPassword(string password, string hashPassword)
        {
            return BC.EnhancedVerify(password, hashPassword);
        }
    }
}
