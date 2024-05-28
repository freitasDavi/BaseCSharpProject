using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Users
{
    public interface IUsersService
    {
        Task Register(RequestCreateUser request);
        Task<string> Login(RequestLogin request);
    }
}
