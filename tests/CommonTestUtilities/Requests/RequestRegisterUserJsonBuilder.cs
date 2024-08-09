using Bogus;
using CashFlow.Communication.Requests.Auth;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build()
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(u => u.Name, f => f.Person.FirstName)
                .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
                .RuleFor(u => u.Password, f => f.Internet.Password(prefix: "!Aa1"));
        }
    }
}
