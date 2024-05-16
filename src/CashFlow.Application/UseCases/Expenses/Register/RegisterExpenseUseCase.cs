using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute (RequestExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisterExpenseJson { };
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ArgumentException("fuck");
            }
        }
    }
}
