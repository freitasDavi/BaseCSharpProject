using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Requests.Incomes;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.Users;
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
            CreateMap<RequestCreateUser, User>();
            CreateMap<CreateIncomeRequest, Income>();

            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(destiny => destiny.Password, config => config.Ignore());

            
            CreateMap<RequestExpenseJson, Expense>()
                .ForMember(dest => dest.Tags, config => config.MapFrom(source => source.Tags.Distinct()));

            CreateMap<Communication.Enums.Tag, Domain.Entities.Tag>()
                .ForMember(dest => dest.Value, config => config.MapFrom(source => source));
        }

        private void EntityToResponse ()
        {
            CreateMap<Expense, ResponseRegisterExpenseJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            
            CreateMap<Expense, ResponseExpenseJson>()
                .ForMember(dest => dest.Tags, config => config.MapFrom(source => source.Tags.Select(tag => tag.Value)));

            CreateMap<User, ResponseUserProfileJson>();
        }
    }
}
