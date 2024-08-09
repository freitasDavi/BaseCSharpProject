using CashFlow.Communication.Requests.Users;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users
{
    public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
        }
    }
}
