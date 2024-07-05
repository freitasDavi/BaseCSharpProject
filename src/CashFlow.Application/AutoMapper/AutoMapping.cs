using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Requests.Incomes;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity ()
        {
            CreateMap<RequestExpenseJson, Expense>();
            CreateMap<RequestCreateUser, User>();
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(destiny => destiny.Password, config => config.Ignore());
            CreateMap<CreateIncomeRequest, Income>();
        }

        private void EntityToResponse ()
        {
            CreateMap<Expense, ResponseRegisterExpenseJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            CreateMap<Expense, ResponseExpenseJson>();

        }
    }
}
