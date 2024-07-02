using CashFlow.Communication.Requests.Auth;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Nome em branco");
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser em branco")
                .EmailAddress()
                .WithMessage("Email deve ser válido");


            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>()); 
        }
    }
}
