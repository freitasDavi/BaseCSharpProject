using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future.");
            RuleFor(x => x.PaymentType).IsInEnum().WithMessage("Invalid payment type.");
        }
    }
}
