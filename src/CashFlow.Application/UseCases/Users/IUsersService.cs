using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users
{
    public interface IUsersService
    {
        Task<ResponseRegisteredUserJson> Register(RequestRegisterUserJson request);
        //Task Register(RequestCreateUser request);
        //Task<string> Login(RequestLogin request);
    }
}
