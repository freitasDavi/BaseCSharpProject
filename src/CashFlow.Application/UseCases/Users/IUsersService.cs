using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Users
{
    public interface IUsersService
    {
        Task<ResponseRegisteredUserJson> Register(RequestRegisterUserJson request);
        Task<ResponseRegisteredUserJson> Login(RequestLogin request);
        Task<User> GetUserByToken(string token);
    }
}
